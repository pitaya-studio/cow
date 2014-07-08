using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyCow.Model
{
    /// <summary>
    /// 牛d
    /// </summary>
    public class Cow
    {
        public const double DAYS_OF_COW_MONTH = 30.5;
        public const int MONTHS_OF_NULLPARITY = 14;
        /// <summary>
        /// 耳号，系统产生
        /// </summary>
        public int EarNum { get; set; }
        /// <summary>
        /// 牧场显示耳号，牧场自定义，本牧场唯一
        /// </summary>
        public string DisplayEarNum { get; set; }
        /// <summary>
        /// 牛群ID
        /// </summary>
        public int GroupID { get; set; }
        /// <summary>
        /// 牛群名
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// 繁殖状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 牧场ID
        /// </summary>
        public string FarmCode { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// 月龄
        /// </summary>
        public double AgeMonth 
        {
            get
            {
                return Math.Round(DateTime.Now.Subtract(BirthDate).TotalDays / Cow.DAYS_OF_COW_MONTH, 1);
            }
        }
        /// <summary>
        /// 出生体重
        /// </summary>
        public float BirthWeight { get; set; }
        /// <summary>
        /// 花色，黑白，黄等
        /// </summary>
        public string Color { get; set; }
        
        /// <summary>
        /// 牛日龄
        /// </summary>
        public int AgeDay
        {
            get
            {
                return Convert.ToInt32(DateTime.Now.Subtract(BirthDate).TotalDays);
            }
        }
        /// <summary>
        /// 是否病牛，指必须隔离或不能奶入罐的。
        /// </summary>
        public bool IsIll { get; set; }
    }
}
