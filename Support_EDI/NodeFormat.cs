using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Support_EDI
{
    public class NodeFormat
    {
        /// <summary>
        /// Writer: Hai.Vu
        /// Purpose: Write Group for Output
        /// </summary>
        public static StringBuilder genGroupOutPut(string name, string loop, int xChildCount, int xActive)
        {
            try
            {
                if (string.IsNullOrEmpty(loop)) loop = "1";
                if ("Y".Equals(loop)) loop = "999";
                StringBuilder str = new StringBuilder();
                str.Append("<Group>									");
                str.Append("<ID>1</ID>                              ");
                str.Append("<Name>" + name.Substring(1) + "_GRP</Name>                   ");
                str.Append("<Description></Description>             ");
                str.Append("<Active>" + xActive + "</Active>                      ");
                str.Append("<ChildCount>" + xChildCount + "</ChildCount>              ");
                str.Append("<Note></Note>                           ");
                str.Append("<Min>0</Min>                            ");
                str.Append("<Max>" + loop + "</Max>                            ");
                str.Append("<PromoteGroup>no</PromoteGroup>         ");
                str.Append("<GroupChoiceType>0</GroupChoiceType>    ");
                str.Append("<OrderingType>0</OrderingType>          ");
                str.Append("<OrderingTag></OrderingTag>             ");
                str.Append("<UsageRelatedFieldName/> ");
                return str;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Writer: Hai.Vu
        /// Purpose: Write PosRecord for Output
        /// </summary>
        public static StringBuilder genPosRecord(string name, string loop, int xChildCount, int xActive, string xTag)
        {
            try
            {
                if (string.IsNullOrEmpty(loop)) loop = "1";
                if ("Y".Equals(loop)) loop = "999";
                StringBuilder str = new StringBuilder();
                str.Append("<PosRecord>									");
                str.Append("<ID>1</ID>                                  ");
                if (name.Length > 5 && (name.Substring(0, 5).Equals("OPEN_") || name.Substring(0, 6).Equals("CLOSE_")))
                {
                    str.Append("<Name>" + name + "</Name>                    ");
                }
                else
                {
                    str.Append("<Name>" + name + "_REC</Name>                    ");
                }

                str.Append("<Description></Description>                 ");
                str.Append("<Active>" + xActive + "</Active>                          ");
                str.Append("<ChildCount>" + xChildCount + "</ChildCount>                  ");
                str.Append("<Note></Note>                               ");
                str.Append("<Min>0</Min>                                ");
                str.Append("<Max>" + loop + "</Max>                                ");
                str.Append("<LoopCtl>normal</LoopCtl>                   ");
                str.Append("<OrderingType>0</OrderingType>              ");
                str.Append("<OrderingTag></OrderingTag>                 ");
                str.Append("<UsageRelatedFieldName/><BlockSig>          ");
                if (name.Length > 5 && (name.Substring(0, 5).Equals("OPEN_") || name.Substring(0, 6).Equals("CLOSE_")))
                {
                    str.Append("<Tag>{" + name.Replace("OPEN_", "").Replace("CLOSE_", "") + "</Tag>                      ");
                }
                else if (xTag.Equals("$%%$"))
                {
                    str.Append("<Tag>" + xTag + "</Tag>                      ");
                }
                else
                {
                    str.Append("<Tag>" + name + ":</Tag>                      ");
                }
                str.Append("<TagPos>0</TagPos>                          ");
                str.Append("<KeyFieldID>0</KeyFieldID>                  ");
                str.Append("<KeyFieldData>0</KeyFieldData>              ");
                str.Append("<KeyFieldAction>65535</KeyFieldAction>      ");
                str.Append("<Tag></Tag>                                 ");
                str.Append("<TagPos>0</TagPos>                          ");
                str.Append("<KeyFieldID>0</KeyFieldID>                  ");
                str.Append("<KeyFieldData>0</KeyFieldData>              ");
                str.Append("<KeyFieldAction>0</KeyFieldAction>          ");
                str.Append("</BlockSig>                                 ");
                str.Append("<TagLength>0</TagLength>                    ");
                return str;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Writer: Hai.Vu
        /// Purpose: Write Field for Output
        /// </summary>
        public static StringBuilder genFieldOutput(string name, string mc, string max, int IdLink, int Id, string item, int xActive, int xStartPos)
        {
            try
            {
                StringBuilder str = new StringBuilder();
                if (string.IsNullOrEmpty(max)) max = "512";
                str.Append("<Field>										");
                str.Append("<ID>" + Id + "</ID>                                     ");
                str.Append("<Name>" + name + "</Name>                        ");
                str.Append("<Description>" + item + "</Description>                    ");
                str.Append("<Active>" + xActive + "</Active>                             ");
                str.Append("<ChildCount>1</ChildCount>                     ");
                str.Append("<Note></Note>                                  ");
                if (mc.Equals("M"))
                {
                    str.Append("<Mandatory>yes</Mandatory>                      ");
                }
                else
                {
                    str.Append("<Mandatory>no</Mandatory>                      ");
                }
                str.Append("<NotUsed>no</NotUsed>                          ");
                str.Append("<FieldNumber>0</FieldNumber>                   ");
                str.Append("<StoreGroup>65535</StoreGroup>                 ");
                str.Append("<StoreField>65535</StoreField>                 ");
                str.Append("<BusinessName></BusinessName>                  ");
                str.Append("<StoreLimit>                                   ");
                str.Append("<MaxLen>" + max + "</MaxLen>                           ");
                str.Append("<MinLen>0</MinLen>                             ");
                str.Append("<Signed>no</Signed>                            ");
                str.Append("<DataType>string</DataType>                    ");
                str.Append("<ImpliedDecimalPos>0</ImpliedDecimalPos>       ");
                str.Append("<ImplicitDecimal>no</ImplicitDecimal>          ");
                str.Append("<AllowSignedDecimal>0</AllowSignedDecimal>     ");
                str.Append("<Format></Format>                              ");
                str.Append("<BinaryOutput>0</BinaryOutput>                 ");
                str.Append("<BinaryWidth>0</BinaryWidth>                   ");
                str.Append("</StoreLimit>                                  ");
                if (IdLink != 0) str.Append(" <Link>" + IdLink + "</Link> ");
                str.Append("<StartPos>" + xStartPos + "</StartPos>                         ");
                str.Append("<Length>" + max + "</Length>                           ");
                str.Append("<Justify>left</Justify>                        ");
                str.Append("<PadChar>SP</PadChar>                          ");
                str.Append("<PadHighByte>0</PadHighByte>                   ");
                str.Append("<Binary>0</Binary>                             ");
                str.Append("</Field>                                       ");
                return str;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Writer: Hai.Vu
        /// Purpose: Write Group for Input
        /// </summary>
        public static StringBuilder genGroupInput(string name, string loop)
        {
            if (string.IsNullOrEmpty(loop)) loop = "1";
            if ("Y".Equals(loop)) loop = "999";
            StringBuilder strRtn = new StringBuilder();
            try
            {
                strRtn.Append(" <Group>									");
                strRtn.Append(" <ID>2</ID>                              ");
                strRtn.Append(" <Name>TMP_" + name.Trim().Substring(1) + "</Name>               ");
                strRtn.Append(" <Description></Description> ");
                strRtn.Append(" <Active>1</Active>                      ");
                strRtn.Append(" <ChildCount>1</ChildCount>              ");
                strRtn.Append(" <Note></Note>                           ");
                strRtn.Append(" <Min>0</Min>                            ");
                strRtn.Append(" <Max>" + loop + "</Max>                            ");
                strRtn.Append(" <PromoteGroup>no</PromoteGroup>         ");
                strRtn.Append(" <GroupChoiceType>0</GroupChoiceType>    ");
                strRtn.Append(" <OrderingType>0</OrderingType>          ");
                strRtn.Append(" <OrderingTag></OrderingTag>             ");
                strRtn.Append(" <UsageRelatedFieldName/>                ");


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return strRtn;
        }
        /// <summary>
        /// Writer: Hai.Vu
        /// Purpose: Write Segment for Input
        /// </summary>
        public static StringBuilder genSegment(string name, string loop)
        {
            if (string.IsNullOrEmpty(loop)) loop = "1";
            if ("Y".Equals(loop)) loop = "999";
            StringBuilder strRtn = new StringBuilder();
            try
            {
                strRtn.Append(" <Segment>									");
                strRtn.Append(" <ID>4</ID>                                   ");
                strRtn.Append(" <Name>TMP_" + name + "</Name>               ");
                strRtn.Append(" <Description></Description>      ");
                strRtn.Append(" <Active>1</Active>                           ");
                strRtn.Append(" <ChildCount>1</ChildCount>                   ");
                strRtn.Append(" <Note></Note>                                ");
                strRtn.Append(" <Min>0</Min>                                 ");
                strRtn.Append(" <Max>" + loop + "</Max>                                 ");
                strRtn.Append(" <LoopCtl>normal</LoopCtl>                    ");
                strRtn.Append(" <OrderingType>0</OrderingType>               ");
                strRtn.Append(" <OrderingTag></OrderingTag>                  ");
                strRtn.Append(" <UsageRelatedFieldName/>                     ");
                strRtn.Append(" <BlockSig>                                   ");
                strRtn.Append("     <Tag>$$$</Tag>                              ");
                strRtn.Append("     <TagPos>0</TagPos>                       ");
                strRtn.Append("     <KeyFieldID>0</KeyFieldID>               ");
                strRtn.Append("     <KeyFieldData>65535</KeyFieldData>       ");
                strRtn.Append("     <KeyFieldAction>65535</KeyFieldAction>   ");
                strRtn.Append("     <Tag></Tag>                              ");
                strRtn.Append("     <TagPos>0</TagPos>                       ");
                strRtn.Append("     <KeyFieldID>0</KeyFieldID>               ");
                strRtn.Append("     <KeyFieldData>0</KeyFieldData>           ");
                strRtn.Append("     <KeyFieldAction>0</KeyFieldAction>       ");
                strRtn.Append(" </BlockSig>                                  ");
                strRtn.Append(" <WildCard>no</WildCard>                      ");
                strRtn.Append(" <Binary>no</Binary>                          ");
                strRtn.Append(" <Float>no</Float>                            ");


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return strRtn;
        }
        /// <summary>
        /// Writer: Hai.Vu
        /// Purpose: Write Field for Input
        /// </summary>
        public static StringBuilder genFieldInput(string name, string mc, string max, int Id, string item)
        {
            StringBuilder strRtn = new StringBuilder();
            if (string.IsNullOrEmpty(max.Trim())) max = "512";
            try
            {
                strRtn.Append(" <Field>											   ");
                strRtn.Append(" <ID>" + Id + "</ID>                                         ");
                strRtn.Append(" <Name>TMP_" + name + "</Name>                      ");
                strRtn.Append(" <Description>" + item + "</Description>        ");
                strRtn.Append(" <Active>1</Active>                                 ");
                strRtn.Append(" <ChildCount>1</ChildCount>                         ");
                strRtn.Append(" <Note></Note>                                      ");
                if (mc.Equals("M"))
                {
                    strRtn.Append("<Mandatory>yes</Mandatory>                      ");
                }
                else
                {
                    strRtn.Append("<Mandatory>no</Mandatory>                      ");
                }
                strRtn.Append(" <NotUsed>no</NotUsed>                              ");
                strRtn.Append(" <FieldNumber>0</FieldNumber>                       ");
                strRtn.Append(" <StoreGroup>65535</StoreGroup>                     ");
                strRtn.Append(" <StoreField>65535</StoreField>                     ");
                strRtn.Append(" <BusinessName></BusinessName>                      ");
                strRtn.Append(" <StoreLimit>                                       ");
                strRtn.Append("     <MaxLen>" + max + "</MaxLen>                           ");
                strRtn.Append("     <MinLen>0</MinLen>                             ");
                strRtn.Append("     <Signed>no</Signed>                            ");
                strRtn.Append("     <DataType>string</DataType>                    ");
                strRtn.Append("     <ImpliedDecimalPos>0</ImpliedDecimalPos>       ");
                strRtn.Append("     <ImplicitDecimal>no</ImplicitDecimal>          ");
                strRtn.Append("     <AllowSignedDecimal>0</AllowSignedDecimal>     ");
                strRtn.Append("     <Format></Format>                              ");
                strRtn.Append("     <BinaryOutput>0</BinaryOutput>                 ");
                strRtn.Append("     <BinaryWidth>0</BinaryWidth>                   ");
                strRtn.Append(" </StoreLimit>                                      ");
                strRtn.Append(" <Element>0</Element>                               ");
                strRtn.Append(" <ElementOpt>0</ElementOpt>                         ");
                strRtn.Append(" <SubElement>0</SubElement>                         ");
                strRtn.Append(" <SubElementOpt>0</SubElementOpt>                   ");
                strRtn.Append(" <MinUsage>0</MinUsage>                             ");
                strRtn.Append(" <MaxUsage>1</MaxUsage>                             ");
                strRtn.Append(" <Binary>0</Binary>                                 ");
                strRtn.Append(" <TreatAsRepeat>no</TreatAsRepeat>                  ");
                strRtn.Append(" <AlwaysOutputDelimiter>no</AlwaysOutputDelimiter>  ");
                strRtn.Append(" </Field>										   ");

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return strRtn;
        }
        //private void txtPrefix_ScrollChanged(object sender, ScrollChangedEventArgs e)
        //{
        //    //var textToSync = (sender == txtLinePrefix || sender == txtMC || sender == txtMax || sender == txtLoop) ? txtPrefix : txtLinePrefix;
        //    //txtLinePrefix.ScrollToVerticalOffset(e.VerticalOffset);
        //    //txtLinePrefix.ScrollToHorizontalOffset(e.HorizontalOffset);

        //    //txtPrefix.ScrollToVerticalOffset(e.VerticalOffset);
        //    //txtPrefix.ScrollToHorizontalOffset(e.HorizontalOffset);

        //    //txtMC.ScrollToVerticalOffset(e.VerticalOffset);
        //    //txtMC.ScrollToHorizontalOffset(e.HorizontalOffset);

        //    //txtMax.ScrollToVerticalOffset(e.VerticalOffset);
        //    //txtMax.ScrollToHorizontalOffset(e.HorizontalOffset);

        //    //txtLoop.ScrollToVerticalOffset(e.VerticalOffset);
        //    //txtLoop.ScrollToHorizontalOffset(e.HorizontalOffset);

        //    //int lengthPrefix = Regex.Split(txtPrefix.Text, "\r\n").Length;
        //    //setLengthText(lengthPrefix);

        //}
        //public void setLengthText(int xLength)
        //{
        //    //int lengthMC = Regex.Split(txtMC.Text, "\r\n").Length;
        //    //int lengthMax = Regex.Split(txtMax.Text, "\r\n").Length;
        //    //int lengthLoop = Regex.Split(txtLoop.Text, "\r\n").Length;
        //    //if (lengthLoop < xLength)
        //    //{
        //    //    for (int i = lengthLoop; i < xLength; i++)
        //    //    {
        //    //        txtLoop.AppendText("\r\n");
        //    //    }
        //    //}
        //    //if (lengthMax < xLength)
        //    //{
        //    //    for (int i = lengthMax; i < xLength; i++)
        //    //    {
        //    //        txtMax.AppendText("\r\n");
        //    //    }
        //    //}
        //    //if (lengthMC < xLength)
        //    //{
        //    //    for (int i = lengthMC; i < xLength; i++)
        //    //    {
        //    //        txtMC.AppendText("\r\n");
        //    //    }
        //    //}
        //}
        //private void txtPrefix_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    //String[] textList = Regex.Split(txtPrefix.Text, "\r\n");
        //    //StringBuilder xline = new StringBuilder();
        //    //for (int i = 1; i <= textList.Length; i++)
        //    //{
        //    //    xline.Append(i + "\n");
        //    //}
        //    //txtLinePrefix.Text = xline.ToString();
        //}
    }
}
