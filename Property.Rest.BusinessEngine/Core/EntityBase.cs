using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace IDesign.Core.Business
{
    [Serializable()]
    public abstract class EntityBase<TBusinessObject>
    {
        protected bool _IsNew = false;

        public void MarkAsNew()
        {
            _IsNew = true;
        }

        public string Serialize()
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            XmlSerializer serializer = new XmlSerializer(typeof(TBusinessObject));
            serializer.Serialize(stream, this);
            return ASCIIEncoding.ASCII.GetString(stream.ToArray());
        }

        public TBusinessObject Deserialize(string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TBusinessObject));
            System.IO.MemoryStream stream = new System.IO.MemoryStream(ASCIIEncoding.ASCII.GetBytes(xmlString));
            return (TBusinessObject)(serializer.Deserialize(stream));
        }

        public TBusinessObject Clone()
        {
            return Deserialize(Serialize());
        }

    }
}
