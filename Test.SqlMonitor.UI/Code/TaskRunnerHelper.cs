using Microsoft.EnterpriseManagement;
using Microsoft.EnterpriseManagement.Common;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.Monitoring;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test.SqlMonitor.UI.Code
{
    class TaskRunnerHelper
    {
        static readonly string TestTaskName = "Test.SqlMonitor.MP.AgentTask.OleDbTest";

        private ManagementGroup managementGroup;

        public TaskRunnerHelper(ManagementGroup mg)
        {
            managementGroup = mg;
        }

        private MonitoringObject GetMonitoringObject(Guid id)
        {
            return managementGroup.EntityObjects.GetObject<MonitoringObject>(
                id, ObjectQueryOptions.Default);
        }

        private ManagementPackTask GetTaskByName(string name)
        {
            string taskQuery = string.Format("Name = '{0}'", name);
            ManagementPackTaskCriteria taskCriteria = new ManagementPackTaskCriteria(taskQuery);
            var tasks = managementGroup.TaskConfiguration.GetTasks(taskCriteria);
            return tasks.Single();
        }

        private Microsoft.EnterpriseManagement.Runtime.TaskConfiguration CreateTaskOverrideConfiguration(
            ManagementPackTask task,
            params KeyValuePair<string, string>[] overrides)
        {
            var config = new Microsoft.EnterpriseManagement.Runtime.TaskConfiguration();
            var taskOverrideableParams = task.GetOverrideableParameters();
            foreach (var param in overrides)
            {
                config.Overrides.Add(new Pair<ManagementPackOverrideableParameter, string>(
                    taskOverrideableParams.First(p => p.Name.Equals(param.Key)),
                    param.Value
                    ));
            }
            return config;
        }

        public Microsoft.EnterpriseManagement.Runtime.TaskResult RunTestTask(string connectionString, string query, int queryTimeout)
        {
            MonitoringObject target = GetMonitoringObject(MPGuidReference.AllManagementServersPoolId);
            if (target == null) { throw new ArgumentNullException("Target not found"); }

            ManagementPackTask task = GetTaskByName(TestTaskName);
            var overrideableParams = task.GetOverrideableParameters();

            var config = CreateTaskOverrideConfiguration(task,
                new KeyValuePair<string, string>("ConnectionString", connectionString),
                new KeyValuePair<string, string>("Query", query),
                new KeyValuePair<string, string>("QueryTimeout", queryTimeout.ToString())
                );

            IList<Microsoft.EnterpriseManagement.Runtime.TaskResult> result =
                managementGroup.TaskRuntime.ExecuteTask(target, task, config);
            return result?.FirstOrDefault();
        }
    }
}
