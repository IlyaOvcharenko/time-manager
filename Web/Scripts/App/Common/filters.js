timeManagerFilters.filter('dayIntervalFilter', ['timeManagerAppUtilities', function (timeManagerAppUtilities) {
    return function (input) {
        var result = [];
        angular.forEach(input, function (item) {

            if (timeManagerAppUtilities.isDateInPeriod(item.Date, 0))
                result.push(item);
        });
        return result;
    }
}]);