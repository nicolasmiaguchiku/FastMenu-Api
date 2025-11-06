using FastMenu.Domain.Entities;
using FastMenu.Domain.Filters;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FastMenu.Infrastructure.Stages
{
    public static class FoodFiltersBuildertage
    {
        public static PipelineDefinition<FoodEntity, BsonDocument> FilterFoods (this PipelineDefinition<FoodEntity, BsonDocument> pipelineDefinition,
            FoodFiltersBuilder queryFilter)
        {
            var matchFilter = BuildMatchFilter(queryFilter);
            if (matchFilter != FilterDefinition<BsonDocument>.Empty)
            {
                pipelineDefinition = pipelineDefinition.Match(matchFilter);
            }

            return pipelineDefinition;
        }

        private static FilterDefinition<BsonDocument> BuildMatchFilter(FoodFiltersBuilder queryFilter)
        {
            var filters = new List<FilterDefinition<BsonDocument>>
        {
            MatchByCustomerIds(queryFilter),
            MatchByAssessment(queryFilter),
            MatchByNames(queryFilter),
            MatchByCategorys(queryFilter),
        };

            filters.RemoveAll(filter => filter == FilterDefinition<BsonDocument>.Empty);

            return filters.Count switch
            {
                0 => FilterDefinition<BsonDocument>.Empty,
                1 => filters[0],

                _ => Builders<BsonDocument>.Filter.And(filters)
            };
        }

        private static FilterDefinition<BsonDocument> MatchByCustomerIds(FoodFiltersBuilder queryFilter)
        {
            if (queryFilter?.FoodIds == null || !queryFilter.FoodIds.Any())
            {
                return FilterDefinition<BsonDocument>.Empty;
            }

            var bsonGuids = queryFilter!.FoodIds!
                .Select(id => new BsonBinaryData(id, GuidRepresentation.Standard));

            var filter = new BsonDocument("_id", new BsonDocument("$in", new BsonArray(bsonGuids)));

            return filter;
        }

        private static FilterDefinition<BsonDocument> MatchByAssessment(FoodFiltersBuilder queryFilter)
        {
            if (queryFilter?.Assessment == null || !queryFilter.Assessment.Any())
                return FilterDefinition<BsonDocument>.Empty;

            return new BsonDocument("Assessment", new BsonDocument("$in", new BsonArray(queryFilter.Assessment)));
        }

        private static FilterDefinition<BsonDocument> MatchByCategorys(FoodFiltersBuilder queryFilter)
        {
            if (queryFilter?.Categorys == null || !queryFilter.Categorys.Any())
                return FilterDefinition<BsonDocument>.Empty;

            return new BsonDocument("Category", new BsonDocument("$in",new BsonArray(queryFilter.Categorys.Select(c => c.ToString()))));
        }

        private static FilterDefinition<BsonDocument> MatchByNames(FoodFiltersBuilder queryFilter)
        {
            if (queryFilter?.Names == null || !queryFilter.Names.Any())
                return FilterDefinition<BsonDocument>.Empty;

            return new BsonDocument("Name", new BsonDocument("$in", new BsonArray(queryFilter.Names)));
        }
    }
}
