using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalWebService.Service.RealTimeData
{
    public class Model_AnalogData
    {
        private List<Model_AnalogDataItems> _AnalogDataItems;
        public Model_AnalogData()
        {
            _AnalogDataItems = new List<Model_AnalogDataItems>();
        }
        public List<Model_AnalogDataItems> AnalogDataItems
        {
            get
            {
                return _AnalogDataItems;
            }
            set
            {
                _AnalogDataItems = value;
            }
        }
    }
    public class Model_AnalogDataItems
    {
        private string _OrganizationId;
        private Dictionary<string, decimal> _AnalogData;
        public Model_AnalogDataItems()
        {
            _OrganizationId = "";
            _AnalogData = new Dictionary<string, decimal>();
        }
        public string OrganizationId
        {
            get
            {
                return _OrganizationId;
            }
            set
            {
                _OrganizationId = value;
            }
        }
        public Dictionary<string, decimal> AnalogData
        {
            get
            {
                return _AnalogData;
            }
            set
            {
                _AnalogData = value;
            }
        }
    }

    /// <summary>
    /// 可序列化的数据类型
    /// </summary>
    public class AnalogDataItem_Serialization
    {
        public string ID { get; set; }
        public decimal Value { get; set; }
    }
    /// <summary>
    /// 可序列化的数据集合类型
    /// </summary>
    public class AnalogDataGroup_Serialization
    {
        public DateTime Time { get; set; }
        public string OrganizationId { get; set; }
        public List<AnalogDataItem_Serialization> DataSet { get; set; }
    }
}
