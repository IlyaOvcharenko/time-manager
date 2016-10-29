timeManagerApp.config([
    '$routeProvider',
    function ($routeProvider) {
        $routeProvider.
            when('/tasks', {
                templateUrl: 'Partials/taskList.html',
                controller: 'parentTaskListCtrl'
            }).
            when('/tasks/:id', {
                templateUrl: 'Partials/taskDetails.html',
                controller: 'taskDetailsCtrl'
            }).
            otherwise({
                redirectTo: '/tasks'
            });
    }
]);