var timeManagerApp = angular.module('timeManagerApp', ['ngRoute', 'timeManagerControllers', 'ngResource', 'timeManagerFilters']);

var timeManagerFilters = angular.module('timeManagerFilters', []);

timeManagerApp.factory('Tasks', ['$resource',
    function($resource) {
        return $resource('api/Task/:id', { id: '@id' }, { update: { method: 'PUT' }, query: { method: 'get', isArray: false } });
    }
]);

var timeManagerControllers = angular.module('timeManagerControllers', []);

