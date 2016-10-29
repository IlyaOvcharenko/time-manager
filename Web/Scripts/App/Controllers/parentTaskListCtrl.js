/// <reference path="E:\Std\TimeManager\Web\Templates/taskListTemplate.html" />
/// <reference path="E:\Std\TimeManager\Web\Templates/taskListTemplate.html" />
timeManagerControllers.controller('parentTaskListCtrl', [
    '$scope', '$rootScope', 'Tasks', '$location', 'timeManagerAppUtilities',
function ($scope, $rootScope, Tasks, $location, timeManagerAppUtilities) {
    $scope.search = function () {
        $scope.tasksEntityPage = Tasks.query({ pageNumber: $scope.pageNumber, pageSize: $scope.pageSize, searchText: $scope.searchText }, function() {
            $scope.tasks = $scope.tasksEntityPage.List;
        });
    }

    $scope.reset = function () {
        $scope.listTemplate = "Templates/taskListTemplate.html";
        $scope.pageNumber = 0;
        $scope.pageSize = 10;
        $scope.searchText = '';
        $scope.search();
    }

    $scope.onTaskClick = function () {
        $rootScope.currentTask = this.task;
    }

    $scope.getTaskSpentTime = function (task) {
        var spentTime = getTaskTime(task);
        return spentTime;
    }

    $rootScope.currentTab = 'list';

    $scope.reset();

    function getTaskTime(task) {
        var result = 0;
        angular.forEach(task.Activities, function (item) {
            if (timeManagerAppUtilities.isDateInPeriod(item.Date, 0))
                result += item.SpentTime;
        });
        if (task.ChildTasks && task.ChildTasks.length > 0) {
            angular.forEach(task.ChildTasks, function (item) {
                result += getTaskTime(item);
            });
        }
        return result;
    }
}
]);

