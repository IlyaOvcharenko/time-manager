timeManagerApp.factory('timeManagerAppUtilities', function () {
    return {
        isDateInPeriod: function (date, daysBefore) {
            var beginDate = new Date();
            var endDate = new Date(beginDate.getFullYear(), beginDate.getMonth(), beginDate.getDate() - daysBefore);
            var itemDateTime = new Date(date);
            var itemDate = new Date(itemDateTime.getUTCFullYear(), itemDateTime.getUTCMonth(), itemDateTime.getUTCDate());
            return beginDate.setHours(0, 0, 0, 0) <= itemDate && itemDate <= endDate.setHours(0, 0, 0, 0);
        }
    }
});