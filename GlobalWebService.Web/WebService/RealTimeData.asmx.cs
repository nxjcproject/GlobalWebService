using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using GlobalWebService.Service.RealTimeData;

namespace GlobalWebService.Web.WebService
{
    /// <summary>
    /// RealTimeData 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class RealTimeData : System.Web.Services.WebService
    {
        private const string ValidWriteString = "HTKJ134fqewrg?%%da@@";
        private const string ValidReadString = "HTKJ2016_#*?";
        private static GlobalWebService.Service.RealTimeData.Model_AnalogData AnalogData = new GlobalWebService.Service.RealTimeData.Model_AnalogData();
        private static GlobalWebService.Service.RealTimeData.Model_DigitalData DigitalData = new GlobalWebService.Service.RealTimeData.Model_DigitalData();
        private static GlobalWebService.Service.RealTimeData.Model_StringData StringData = new GlobalWebService.Service.RealTimeData.Model_StringData();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public void SetAnalogData(string myOrganizationId, string[] myTagName, decimal[] myTagValue, string myKeyword)
        {
            if (ValidWriteString == myKeyword)
            {
                int m_OrganizationIndex = -1;
                if (AnalogData == null)
                {
                    AnalogData = new Service.RealTimeData.Model_AnalogData();
                }
                for (int i = 0; i < AnalogData.AnalogDataItems.Count; i++)
                {
                    if (AnalogData.AnalogDataItems[i].OrganizationId == myOrganizationId)
                    {
                        m_OrganizationIndex = i;
                        break;
                    }
                }
                if (m_OrganizationIndex == -1)          //当前没有该组织机构
                {
                    GlobalWebService.Service.RealTimeData.Model_AnalogDataItems m_AnalogDataItems = new Service.RealTimeData.Model_AnalogDataItems();
                    m_AnalogDataItems.OrganizationId = myOrganizationId;
                    if (myTagName != null && myTagValue != null)           //构造新的字典
                    {
                        int m_TagValueCount = myTagName.Length <= myTagValue.Length ? myTagName.Length : myTagValue.Length;
                        for (int i = 0; i < m_TagValueCount; i++)
                        {
                            if (!m_AnalogDataItems.AnalogData.ContainsKey(myTagName[i]))
                            {
                                m_AnalogDataItems.AnalogData.Add(myTagName[i], myTagValue[i]);
                            }
                        }
                    }
                    AnalogData.AnalogDataItems.Add(m_AnalogDataItems);
                }
                else                                        //当前有该组织机构
                {
                    if (myTagName != null && myTagValue != null)           //构造新的字典
                    {
                        int m_TagValueCount = myTagName.Length <= myTagValue.Length ? myTagName.Length : myTagValue.Length;
                        for (int i = 0; i < m_TagValueCount; i++)
                        {
                            if (AnalogData.AnalogDataItems[m_OrganizationIndex].AnalogData.ContainsKey(myTagName[i]))     //如果系统本身有该节点
                            {
                                AnalogData.AnalogDataItems[m_OrganizationIndex].AnalogData[myTagName[i]] = myTagValue[i];
                            }
                            else
                            {
                                AnalogData.AnalogDataItems[m_OrganizationIndex].AnalogData.Add(myTagName[i], myTagValue[i]);
                            }
                        }
                    }
                }
            }
        }
        [WebMethod(Description = "需要解压缩")]
        public void SetAnalogDataCompress(string myOrganizationId, byte[] myTagName, byte[] myTagValue, string myKeyword)
        {
            string[] m_TagName = DataCompression.Function_DefaultCompressionArray.DecompressString(myTagName);
            decimal[] m_TagValue = DataCompression.Function_DefaultCompressionArray.DecompressDecimal(myTagValue);
            SetAnalogData(myOrganizationId, m_TagName, m_TagValue, myKeyword);
        }
        [WebMethod]
        public void SetDigitalData(string myOrganizationId, string[] myTagName, bool[] myTagValue, string myKeyword)
        {
            if (ValidWriteString == myKeyword)
            {
                int m_OrganizationIndex = -1;
                if (DigitalData == null)
                {
                    DigitalData = new Service.RealTimeData.Model_DigitalData();
                }
                for (int i = 0; i < DigitalData.DigitalDataItems.Count; i++)
                {
                    if (DigitalData.DigitalDataItems[i].OrganizationId == myOrganizationId)
                    {
                        m_OrganizationIndex = i;
                        break;
                    }
                }
                if (m_OrganizationIndex == -1)          //当前没有该组织机构
                {
                    GlobalWebService.Service.RealTimeData.Model_DigitalDataItems m_DigitalDataItems = new GlobalWebService.Service.RealTimeData.Model_DigitalDataItems();
                    m_DigitalDataItems.OrganizationId = myOrganizationId;
                    if (myTagName != null && myTagValue != null)           //构造新的字典
                    {
                        int m_TagValueCount = myTagName.Length <= myTagValue.Length ? myTagName.Length : myTagValue.Length;
                        for (int i = 0; i < m_TagValueCount; i++)
                        {
                            if (!m_DigitalDataItems.DigitalData.ContainsKey(myTagName[i]))
                            {
                                m_DigitalDataItems.DigitalData.Add(myTagName[i], myTagValue[i]);
                            }
                        }
                    }
                    DigitalData.DigitalDataItems.Add(m_DigitalDataItems);
                }
                else                                        //当前有该组织机构
                {
                    if (myTagName != null && myTagValue != null)           //构造新的字典
                    {
                        int m_TagValueCount = myTagName.Length <= myTagValue.Length ? myTagName.Length : myTagValue.Length;
                        for (int i = 0; i < m_TagValueCount; i++)
                        {
                            if (DigitalData.DigitalDataItems[m_OrganizationIndex].DigitalData.ContainsKey(myTagName[i]))     //如果系统本身有该节点
                            {
                                DigitalData.DigitalDataItems[m_OrganizationIndex].DigitalData[myTagName[i]] = myTagValue[i];
                            }
                            else
                            {
                                DigitalData.DigitalDataItems[m_OrganizationIndex].DigitalData.Add(myTagName[i], myTagValue[i]);
                            }
                        }
                    }
                }
            }
        }
        [WebMethod(Description = "需要解压缩")]
        public void SetDigitalDataCompress(string myOrganizationId, byte[] myTagName, byte[] myTagValue, string myKeyword)
        {
            string[] m_TagName = DataCompression.Function_DefaultCompressionArray.DecompressString(myTagName);
            bool[] m_TagValue = DataCompression.Function_DefaultCompressionArray.DecompressBoolen(myTagValue);
            SetDigitalData(myOrganizationId, m_TagName, m_TagValue, myKeyword);
        }

        /////////////////////////////////增加文本传输////////////////////////////////
        [WebMethod]
        public void SetStringData(string myOrganizationId, string[] myTagName, string[] myTagValue, string myKeyword)
        {
            if (ValidWriteString == myKeyword)
            {
                int m_OrganizationIndex = -1;
                if (StringData == null)
                {
                    StringData = new Service.RealTimeData.Model_StringData();
                }
                for (int i = 0; i < StringData.StringDataItems.Count; i++)
                {
                    if (StringData.StringDataItems[i].OrganizationId == myOrganizationId)
                    {
                        m_OrganizationIndex = i;
                        break;
                    }
                }
                if (m_OrganizationIndex == -1)          //当前没有该组织机构
                {
                    GlobalWebService.Service.RealTimeData.Model_StringDataItems m_StringDataItems = new Service.RealTimeData.Model_StringDataItems();
                    m_StringDataItems.OrganizationId = myOrganizationId;
                    if (myTagName != null && myTagValue != null)           //构造新的字典
                    {
                        int m_TagValueCount = myTagName.Length <= myTagValue.Length ? myTagName.Length : myTagValue.Length;
                        for (int i = 0; i < m_TagValueCount; i++)
                        {
                            if (!m_StringDataItems.StringData.ContainsKey(myTagName[i]))
                            {
                                m_StringDataItems.StringData.Add(myTagName[i], myTagValue[i]);
                            }
                        }
                    }
                    StringData.StringDataItems.Add(m_StringDataItems);
                }
                else                                        //当前有该组织机构
                {
                    if (myTagName != null && myTagValue != null)           //构造新的字典
                    {
                        int m_TagValueCount = myTagName.Length <= myTagValue.Length ? myTagName.Length : myTagValue.Length;
                        for (int i = 0; i < m_TagValueCount; i++)
                        {
                            if (StringData.StringDataItems[m_OrganizationIndex].StringData.ContainsKey(myTagName[i]))     //如果系统本身有该节点
                            {
                                StringData.StringDataItems[m_OrganizationIndex].StringData[myTagName[i]] = myTagValue[i];
                            }
                            else
                            {
                                StringData.StringDataItems[m_OrganizationIndex].StringData.Add(myTagName[i], myTagValue[i]);
                            }
                        }
                    }
                }
            }
        }
        [WebMethod(Description = "需要解压缩")]
        public void SetStringDataCompress(string myOrganizationId, byte[] myTagName, byte[] myTagValue, string myKeyword)
        {
            string[] m_TagName = DataCompression.Function_DefaultCompressionArray.DecompressString(myTagName);
            string[] m_TagValue = DataCompression.Function_DefaultCompressionArray.DecompressString(myTagValue);
            SetStringData(myOrganizationId, m_TagName, m_TagValue, myKeyword);
        }

        //////////////////////////////////////////////////////////////////////////////

        [WebMethod(Description = "获得开关量数据,返回数组")]
        public DigitalDataGroup_Serialization GetDigitalDataA(string myOrganizationId, string[] myTagName, string myKeyword)
        {
            DigitalDataGroup_Serialization m_DigitalData = new DigitalDataGroup_Serialization();
            m_DigitalData.OrganizationId = myOrganizationId;
            m_DigitalData.Time = DateTime.Now;
            List<DigitalDataItem_Serialization> m_DataItems = new List<DigitalDataItem_Serialization>();
            if (ValidReadString == myKeyword)           //简单的验证
            {
                if (myTagName != null && DigitalData != null)
                {
                    int m_OrganizationIndex = -1;
                    for (int i = 0; i < DigitalData.DigitalDataItems.Count; i++)
                    {
                        if (DigitalData.DigitalDataItems[i].OrganizationId == myOrganizationId)
                        {
                            m_OrganizationIndex = i;
                            break;
                        }
                    }
                    if (m_OrganizationIndex != -1)     //说明有该节点
                    {
                        for (int i = 0; i < myTagName.Length; i++)
                        {
                            if (DigitalData.DigitalDataItems[m_OrganizationIndex].DigitalData.ContainsKey(myTagName[i]))
                            {
                                DigitalDataItem_Serialization m_DigitalDataItemTemp = new DigitalDataItem_Serialization();
                                m_DigitalDataItemTemp.ID = myTagName[i];
                                m_DigitalDataItemTemp.Value = DigitalData.DigitalDataItems[m_OrganizationIndex].DigitalData[myTagName[i]];
                                m_DataItems.Add(m_DigitalDataItemTemp);
                            }
                        }
                    }
                }
            }
            m_DigitalData.DataSet = m_DataItems;
            return m_DigitalData;
        }
        [WebMethod(Description = "获得模拟量数据,返回数组")]
        public AnalogDataGroup_Serialization GetAnalogDataA(string myOrganizationId, string[] myTagName, string myKeyword)
        {
            AnalogDataGroup_Serialization m_AnalogData = new AnalogDataGroup_Serialization();
            m_AnalogData.OrganizationId = myOrganizationId;
            m_AnalogData.Time = DateTime.Now;
            List<AnalogDataItem_Serialization> m_DataItems = new List<AnalogDataItem_Serialization>();
            if (ValidReadString == myKeyword)           //简单的验证
            {

                if (myTagName != null && AnalogData != null)
                {
                    int m_OrganizationIndex = -1;
                    for (int i = 0; i < AnalogData.AnalogDataItems.Count; i++)
                    {
                        if (AnalogData.AnalogDataItems[i].OrganizationId == myOrganizationId)
                        {
                            m_OrganizationIndex = i;
                            break;
                        }
                    }
                    if (m_OrganizationIndex != -1)     //说明有该节点
                    {
                        for (int i = 0; i < myTagName.Length; i++)
                        {
                            if (AnalogData.AnalogDataItems[m_OrganizationIndex].AnalogData.ContainsKey(myTagName[i]))
                            {
                                AnalogDataItem_Serialization m_AnalogDataItemTemp = new AnalogDataItem_Serialization();
                                m_AnalogDataItemTemp.ID = myTagName[i];
                                m_AnalogDataItemTemp.Value = AnalogData.AnalogDataItems[m_OrganizationIndex].AnalogData[myTagName[i]];
                                m_DataItems.Add(m_AnalogDataItemTemp);
                            }
                        }
                    }
                }
            }
            m_AnalogData.DataSet = m_DataItems;
            return m_AnalogData;
        }
        /// <summary>
        /// ///////////////////////获得字符串数据//////////////////
        /// </summary>
        /// <param name="myOrganizationId"></param>
        /// <param name="myTagName"></param>
        /// <param name="myKeyword"></param>
        /// <returns></returns>
        [WebMethod(Description = "获得字符串数据,返回数组")]
        public StringDataGroup_Serialization GetStringDataA(string myOrganizationId, string[] myTagName, string myKeyword)
        {
            StringDataGroup_Serialization m_StringData = new StringDataGroup_Serialization();
            m_StringData.OrganizationId = myOrganizationId;
            m_StringData.Time = DateTime.Now;
            List<StringDataItem_Serialization> m_DataItems = new List<StringDataItem_Serialization>();
            if (ValidReadString == myKeyword)           //简单的验证
            {
                if (myTagName != null && StringData != null)
                {
                    int m_OrganizationIndex = -1;
                    for (int i = 0; i < StringData.StringDataItems.Count; i++)
                    {
                        if (StringData.StringDataItems[i].OrganizationId == myOrganizationId)
                        {
                            m_OrganizationIndex = i;
                            break;
                        }
                    }
                    if (m_OrganizationIndex != -1)     //说明有该节点
                    {
                        for (int i = 0; i < myTagName.Length; i++)
                        {
                            if (StringData.StringDataItems[m_OrganizationIndex].StringData.ContainsKey(myTagName[i]))
                            {
                                StringDataItem_Serialization m_StringDataItemTemp = new StringDataItem_Serialization();
                                m_StringDataItemTemp.ID = myTagName[i];
                                m_StringDataItemTemp.Value = StringData.StringDataItems[m_OrganizationIndex].StringData[myTagName[i]];
                                m_DataItems.Add(m_StringDataItemTemp);
                            }
                        }
                    }
                }
            }
            m_StringData.DataSet = m_DataItems;
            return m_StringData;
        }
        [WebMethod(Description = "获得object数据,返回数组")]
        public ObjectDataGroup_Serialization GetObjectDataA(string myOrganizationId, string[] myTagName, string myKeyword)
        {
            ObjectDataGroup_Serialization m_ObjectData = new ObjectDataGroup_Serialization();
            m_ObjectData.OrganizationId = myOrganizationId;
            m_ObjectData.Time = DateTime.Now;
            List<ObjectDataItem_Serialization> m_DataItems = new List<ObjectDataItem_Serialization>();

            DigitalDataGroup_Serialization m_DigitalDataItems = GetDigitalDataA(myOrganizationId, myTagName, myKeyword);
            AnalogDataGroup_Serialization m_AnalogDataItems = GetAnalogDataA(myOrganizationId, myTagName, myKeyword);
            StringDataGroup_Serialization m_StringDataItems = GetStringDataA(myOrganizationId, myTagName, myKeyword);
            for (int i = 0; i < m_DigitalDataItems.DataSet.Count; i++)
            {
                ObjectDataItem_Serialization m_ObjectDataItem = new ObjectDataItem_Serialization();
                m_ObjectDataItem.ID = m_DigitalDataItems.DataSet[i].ID;
                m_ObjectDataItem.Value = m_DigitalDataItems.DataSet[i].Value;
                m_DataItems.Add(m_ObjectDataItem);
            }
            for (int i = 0; i < m_AnalogDataItems.DataSet.Count; i++)
            {
                ObjectDataItem_Serialization m_ObjectDataItem = new ObjectDataItem_Serialization();
                m_ObjectDataItem.ID = m_AnalogDataItems.DataSet[i].ID;
                m_ObjectDataItem.Value = m_AnalogDataItems.DataSet[i].Value;
                m_DataItems.Add(m_ObjectDataItem);
            }
            for (int i = 0; i < m_StringDataItems.DataSet.Count; i++)
            {
                ObjectDataItem_Serialization m_ObjectDataItem = new ObjectDataItem_Serialization();
                m_ObjectDataItem.ID = m_StringDataItems.DataSet[i].ID;
                m_ObjectDataItem.Value = m_StringDataItems.DataSet[i].Value;
                m_DataItems.Add(m_ObjectDataItem);
            }
            m_ObjectData.DataSet = m_DataItems;
            return m_ObjectData;
        }
        /////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        ///
        /// </summary>
        /// <param name="myOrganizationId"></param>
        /// <param name="myTagName"></param>
        /// <param name="myKeyword"></param>
        /// <returns></returns>
        [WebMethod(Description = "获得开关量数据,返回json")]
        public string GetDigitalDataS(string myOrganizationId, string myTagName, string myKeyword)
        {
            string m_DigitalData = "";
            string[] m_TagName = myTagName.Split(',');
            if (ValidReadString == myKeyword)           //简单的验证
            {
                if (m_TagName != null && DigitalData != null)
                {
                    int m_OrganizationIndex = -1;
                    for (int i = 0; i < DigitalData.DigitalDataItems.Count; i++)
                    {
                        if (DigitalData.DigitalDataItems[i].OrganizationId == myOrganizationId)
                        {
                            m_OrganizationIndex = i;
                            break;
                        }
                    }
                    if (m_OrganizationIndex != -1)     //说明有该节点
                    {
                        for (int i = 0; i < m_TagName.Length; i++)
                        {
                            if (DigitalData.DigitalDataItems[m_OrganizationIndex].DigitalData.ContainsKey(m_TagName[i]))
                            {
                                if (i == 0)
                                {
                                    m_DigitalData = "{\"Id\":\"" + m_TagName[i] + "\",\"Value\":\"" + DigitalData.DigitalDataItems[m_OrganizationIndex].DigitalData[m_TagName[i]].ToString() + "\"}";
                                }
                                else
                                {
                                    m_DigitalData = m_DigitalData + ",{\"Id\":\"" + m_TagName[i] + "\",\"Value\":\"" + DigitalData.DigitalDataItems[m_OrganizationIndex].DigitalData[m_TagName[i]].ToString() + "\"}";
                                }
                            }
                        }
                    }
                }
            }
            return "[" + m_DigitalData + "]";
        }
        [WebMethod(Description = "获得模拟量数据,返回json")]
        public string GetAnalogDataS(string myOrganizationId, string myTagName, string myKeyword)
        {
            string m_AnalogData = "";
            string[] m_TagName = myTagName.Split(',');
            if (ValidReadString == myKeyword)           //简单的验证
            {
                if (m_TagName != null && AnalogData != null)
                {
                    int m_OrganizationIndex = -1;
                    for (int i = 0; i < AnalogData.AnalogDataItems.Count; i++)
                    {
                        if (AnalogData.AnalogDataItems[i].OrganizationId == myOrganizationId)
                        {
                            m_OrganizationIndex = i;
                            break;
                        }
                    }
                    if (m_OrganizationIndex != -1)     //说明有该节点
                    {
                        for (int i = 0; i < m_TagName.Length; i++)
                        {
                            if (AnalogData.AnalogDataItems[m_OrganizationIndex].AnalogData.ContainsKey(m_TagName[i]))
                            {
                                if (i == 0)
                                {
                                    m_AnalogData = "{\"Id\":\"" + m_TagName[i] + "\",\"Value\":\"" + AnalogData.AnalogDataItems[m_OrganizationIndex].AnalogData[m_TagName[i]].ToString() + "\"}";
                                }
                                else
                                {
                                    m_AnalogData = m_AnalogData + ",{\"Id\":\"" + m_TagName[i] + "\",\"Value\":\"" + AnalogData.AnalogDataItems[m_OrganizationIndex].AnalogData[m_TagName[i]].ToString() + "\"}";
                                }
                            }
                        }
                    }
                }
            }
            return m_AnalogData;
        }
        [WebMethod(Description = "获得字符串数据,返回json")]
        public string GetStringDataS(string myOrganizationId, string myTagName, string myKeyword)
        {
            string m_StringData = "";
            string[] m_TagName = myTagName.Split(',');
            if (ValidReadString == myKeyword)           //简单的验证
            {
                if (m_TagName != null && StringData != null)
                {
                    int m_OrganizationIndex = -1;
                    for (int i = 0; i < StringData.StringDataItems.Count; i++)
                    {
                        if (StringData.StringDataItems[i].OrganizationId == myOrganizationId)
                        {
                            m_OrganizationIndex = i;
                            break;
                        }
                    }
                    if (m_OrganizationIndex != -1)     //说明有该节点
                    {
                        for (int i = 0; i < m_TagName.Length; i++)
                        {
                            if (StringData.StringDataItems[m_OrganizationIndex].StringData.ContainsKey(m_TagName[i]))
                            {
                                if (i == 0)
                                {
                                    m_StringData = "{\"Id\":\"" + m_TagName[i] + "\",\"Value\":\"" + StringData.StringDataItems[m_OrganizationIndex].StringData[m_TagName[i]] + "\"}";
                                }
                                else
                                {
                                    m_StringData = m_StringData + ",{\"Id\":\"" + m_TagName[i] + "\",\"Value\":\"" + StringData.StringDataItems[m_OrganizationIndex].StringData[m_TagName[i]] + "\"}";
                                }
                            }
                        }
                    }
                }
            }
            return m_StringData;
        }
    }
}
