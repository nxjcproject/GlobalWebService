using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalWebService.Service.RealTimeData
{
    public class Model_DigitalData
    {
        private List<Model_DigitalDataItems> _DigitalDataItems;
        public Model_DigitalData()
        {
            _DigitalDataItems = new List<Model_DigitalDataItems>();
        }
        public List<Model_DigitalDataItems> DigitalDataItems
        {
            get
            {
                return _DigitalDataItems;
            }
            set
            {
                _DigitalDataItems = value;
            }
        }
    }
    public class Model_DigitalDataItems
    {
        private string _OrganizationId;
        private Dictionary<string, bool> _DigitalData;
        public Model_DigitalDataItems()
        {
            _OrganizationId = "";
            _DigitalData = new Dictionary<string, bool>();
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
        public Dictionary<string, bool> DigitalData
        {
            get
            {
                return _DigitalData;
            }
            set
            {
                _DigitalData = value;
            }
        }
    }
    /// <summary>
    /// 可序列化的数据类型
    /// </summary>
    public class DigitalDataItem_Serialization
    {
        public string ID { get; set; }
        public bool Value { get; set; }
    }
    /// <summary>
    /// 可序列化的数据集合类型
    /// </summary>
    public class DigitalDataGroup_Serialization
    {
        public DateTime Time { get; set; }
        public string OrganizationId { get; set; }
        public List<DigitalDataItem_Serialization> DataSet { get; set; }
    }
}
