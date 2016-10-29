timeManagerControllers.controller('taskDetailsCtrl', [
    '$scope', '$rootScope', 'Tasks', '$location', 'timeManagerAppUtilities','$routeParams',
    function ($scope, $rootScope, Tasks, $location, timeManagerAppUtilities, $routeParams) {
        $scope.load = function () {
            if (!$rootScope.currentTask || $rootScope.currentTask.Id != $routeParams.id) {
                $rootScope.currentTask = Tasks.get({ id: $routeParams.id }, function () {
                    if ($rootScope.currentTask.ParentTaskId)
                        getParentTask($rootScope.currentTask);
                    $scope.task = $.extend({}, $rootScope.currentTask);
                });
            }
            if ($rootScope.currentTask.ParentTaskId)
               getParentTask($rootScope.currentTask);
            $scope.task = $.extend({}, $rootScope.currentTask);

            //init
            $scope.isEdit = false;
            $rootScope.currentTab = 'details';
            $scope.taskListPageNumber = 0;
            $scope.taskListPageSize = 10;
            $scope.taskListSearchText = '';
            $scope.listTemplate = "Templates/taskListTemplate.html";
        }

        $scope.cancel = function() {
            $scope.load();
        }

        $scope.openParentTaskModal = function () {
            $scope.tasksEntityPage = Tasks.query({ pageNumber: $scope.taskListPageNumber, pageSize: $scope.taskListPageSize, searchText: $scope.taskListSearchText }, function() {
                $scope.tasks = $scope.tasksEntityPage.List;
                $('#parentTaskModal').modal('show');
            });
            
        };

        $scope.onTaskClick = function() {
            $scope.selectedParentTask = this.task;
        };

        $scope.onParentTaskModalSaveBtnClick = function() {
            $scope.task.ParentTask = $scope.selectedParentTask;
            $scope.task.ParentTaskId = $scope.selectedParentTask.Id;
            $('#parentTaskModal').modal('hide');
        }

        function getParentTask(task) {
            task.ParentTask = Tasks.get({ id: task.ParentTaskId });
        }

        $scope.load();
    }
]);