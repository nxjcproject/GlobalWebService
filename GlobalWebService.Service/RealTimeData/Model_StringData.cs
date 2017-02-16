using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalWebService.Service.RealTimeData
{
    public class Model_StringData
    {
        private List<Model_StringDataItems> _StringDataItems;
        public Model_StringData()
        {
            _StringDataItems = new List<Model_StringDataItems>();
        }
        public List<Model_StringDataItems> StringDataItems
        {
            get
            {
                return _StringDataItems;
            }
            set
            {
                _StringDataItems = value;
            }
        }
    }
    public class Model_StringDataItems
    {
        private string _OrganizationId;
        private Dictionary<string, string> _StringData;
        public Model_StringDataItems()
        {
            _OrganizationId = "";
            _StringData = new Dictionary<string, string>();
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
        public Dictionary<string, string> StringData
        {
            get
            {
                return _StringData;
            }
            set
            {
                _StringData = value;
            }
        }
    }

    /// <summary>
    /// 可序列化的数据类型
    /// </summary>
    public class StringDataItem_Serialization
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }
    /// <summary>
    /// 可序列化的数据集合类型
    /// </summary>
    public class StringDataGroup_Serialization
    {
        public DateTime Time { get; set; }
        public string OrganizationId { get; set; }
        public List<StringDataItem_Serialization> DataSet { get; set; }
    }
}
