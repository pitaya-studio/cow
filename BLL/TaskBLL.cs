using DairyCow.DAL;
using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace DairyCow.BLL
{
     
    public class TaskBLL
    {
        TaskDAL taskDAL = new TaskDAL();

        /// <summary>
        /// 获取某人未完成的最近任务
        /// </summary>
        /// <param name="operatorID">任务人ID</param>
        /// <returns>未完成任务List</returns>
        public List<DairyTask> GetRecentUnfinishedTaskList(int operatorID,int pastureID)
        {
            List<DairyTask> list = new List<DairyTask>();
            DataTable tb=taskDAL.GetRecentUnfinishedTasksByOperator(operatorID,pastureID);
            foreach (DataRow item in tb.Rows)
            {
                list.Add(WrapTaskItem(item));
            }
            return list;
        }

        public List<DairyTask> GetAllTasks(int pastureID)
        {
            List<DairyTask> list = new List<DairyTask>();
            DataTable tb = taskDAL.GetAllTasks(pastureID);
            foreach (DataRow item in tb.Rows)
            {
                list.Add(WrapTaskItem(item));
            }
            return list;
        }

        public List<DairyTask> GetUnfinishedTasks(int pastureID)
        {
            List<DairyTask> list = new List<DairyTask>();
            DataTable tb = taskDAL.GetRecentUnfinishedTaskList(pastureID);
            foreach (DataRow item in tb.Rows)
            {
                list.Add(WrapTaskItem(item));
            }
            return list;
        }        

        /// <summary>
        /// 封装任务项
        /// </summary>
        /// <param name="row">数据行</param>
        /// <returns>任务</returns>
        public DairyTask WrapTaskItem(DataRow row)
        {
            DairyTask t = new DairyTask();
            if (row!=null)
            {
                t.ID = Convert.ToInt32(row["ID"]);
                t.StartTime = Convert.ToDateTime(row["StartTime"]);
                t.DeadLine = Convert.ToDateTime(row["DeadLine"]);
                switch (Convert.ToInt32(row["TaskStatus"]))
                {
                    case 0:
                        t.Status = DairyTaskStatus.Initial;
                        break;
                    case 1:
                        t.Status = DairyTaskStatus.Completed;
                        break;
                    default:
                        break;
                }
                int taskTypeNum=Convert.ToInt32(row["TaskType"]);
                switch (taskTypeNum)
                {
                    case 0:
                        t.TaskType = TaskType.InseminationTask;
                        break;
                    case 1:
                        t.TaskType = TaskType.InitialInspectionTask;
                        break;
                    case 2:
                        t.TaskType = TaskType.ReInspectionTask;
                        break;
                    case 3:
                        t.TaskType = TaskType.Day21ToBornTask;
                        break;
                    case 4:
                        t.TaskType = TaskType.Day7ToBornTask;
                        break;
                    case 5:
                        t.TaskType = TaskType.Day3AfterBornTask;
                        break;
                    case 6:
                        t.TaskType = TaskType.Day10AfterBornTask;
                        break;
                    case 7:
                        t.TaskType = TaskType.Day15AfterBornTask;
                        break;
                    case 8:
                        t.TaskType = TaskType.ImmuneTask;
                        break;
                    case 9:
                        t.TaskType = TaskType.QuarantineTask;
                        break;
                    case 10:
                        t.TaskType = TaskType.GroupingTask;
                        break;
                    default:
                        break;
                }
                if (row["RoleID"]!=DBNull.Value)
                {
                    t.RoleID= Convert.ToInt32(row["RoleID"]);
                }
                if (row["OperatorID"] != DBNull.Value)
                {
                    t.RoleID = Convert.ToInt32(row["OperatorID"]);
                }
                if (row["FinishedTime"] != DBNull.Value)
                {
                    t.CompleteTime = Convert.ToDateTime(row["FinishedTime"]);
                }
                if (row["InputTime"] != DBNull.Value)
                {
                    t.InputTime = Convert.ToDateTime(row["InputTime"]);
                }
            }
            return t;
        }

        //以下为在各个任务单产生，回填活动，所需要的接口
        /// <summary>
        /// 创建一件任务
        /// </summary>
        /// <param name="myTask">DairyTask</param>
        public bool AddTask(DairyTask myTask)
        {
            bool isSuccessful=false;
            //
            TaskDAL dal=new TaskDAL();
            int i=dal.InsertTask(myTask);
            if (i==1)
            {
                isSuccessful = true;
            }
            return isSuccessful;
        }

        /// <summary>
        /// 更新任务
        /// </summary>
        /// <param name="myTask">DairyTask</param>
        public bool UpdateTask(DairyTask myTask)
        {
            bool isSuccessful = false;
            TaskDAL dal = new TaskDAL();
            int i = dal.UpdateTask(myTask);
            if (i==1)
            {
                isSuccessful = true;
            }
            return isSuccessful;
        }

        /// <summary>
        /// 删除无用的之前的妊检任务单，可能发生返情重配
        /// </summary>
        /// <param name="earNum">耳号</param>
        /// <param name="isInitial">初检true,复检false</param>
        /// <returns>删除记录数</returns>
        public int RemovePreviousInspectionTasks(int earNum,bool isInitial)
        {
            int i = 0;
            return i;
        }

        /// <summary>
        /// 删除无用的之前的产前任务单，可能发生流产,早产
        /// </summary>
        /// <param name="earNum">耳号</param>
        /// <param name="isInitial">初检true,复检false</param>
        /// <returns>删除记录数</returns>
        public int RemovePreviousBeforeBornTasks(int earNum)
        {
            int i = 0;
            return i;
        }

        /// <summary>
        /// 发情配种，输入界面动作
        /// </summary>
        public void CompleteInsemination()
        {
            //添加任务记录，添加即已完成 Todo

            //添加配种记录

            //删除无效的妊检任务单
            //产生新妊检任务单
        }
        public void CompleteInitialInspection()
        {
            //添加初检记录
            //更新任务记录，标记完成
            //
            //生成新复检任务单
        }

        public void CompleteReInspection()
        {
            //添加初检记录
            //更新任务记录，标记完成
            //
            //生成产前21天任务单
        }

        public void CompleteDay21ToBorn()
        {
            //更新任务记录，标记完成
            //
            //生成产前7天任务单
        }

        public void CompleteDay3AfterBorn()
        {
            //此任务单在，产犊界面/事件中产生，或者流产早产；流产等会取消之前的未完成产前任务单
            //更新任务记录，标记完成
        }

        public void CompleteDay10AfterBorn()
        {
            //此任务单在，产犊界面/事件中产生，或者流产早产；流产等会取消之前的未完成产前任务单
            //更新任务记录，标记完成
        }
        public void CompleteDay15AfterBorn()
        {
            //此任务单在，产犊界面/事件中产生，或者流产早产；流产等会取消之前的未完成产前任务单
            //更新任务记录，标记完成
        }

        public void CompleteImmune()
        {
            //更新任务记录，标记完成
        }

        public void AddImmuneRecord()
        { 
            //每头牛做增加操作时调用本方法
        }
        public void CompleteQuarantine()
        {
            //更新任务记录，标记完成
        }

        public void AddQuarantineRecord()
        {
            //每头牛做增加操作时调用本方法
        }

        public void CompleteGrouping()
        {
            //各种事件触发产生分群要求，产生任务单
            //饲养员按要求操作，回填完成时间

        }


    }
}
