using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalWebService.Service.RealTimeData
{
    /// <summary>
    /// 可序列化的数据类型
    /// </summary>
    public class ObjectDataItem_Serialization
    {
        public string ID { get; set; }
        public object Value { get; set; }
    }
    /// <summary>
    /// 可序列化的数据集合类型
    /// </summary>
    public class ObjectDataGroup_Serialization
    {
        public DateTime Time { get; set; }
        public string OrganizationId { get; set; }
        public List<ObjectDataItem_Serialization> DataSet { get; set; }
    }
}
