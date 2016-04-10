using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SNS.Models;
using System.IO.Ports;
using System.Threading;

namespace SNS.DAL
{
    public class MobileHandler
    {
        List<string> NumberList = new List<string>();
        public static void Save(Mobile mob)
        {
            
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                db.Mobiles.Add(mob);
                db.SaveChanges();
            }
        }
        public static void SaveFirstPort() {
            var port = Message("Port");
            Mobile mb = new Mobile();
            if (port==null)
            {
                mb.Title = "Port";
                mb.Message = "COM2";
                Save(mb);
            }
            
        }

        public static Mobile Message(string Title)
        {
            try
            {
                using (CourseMetarialEntities db = new CourseMetarialEntities())
                {
                    return db.Mobiles.Where(m => m.Title == Title).First();
                }
            }
            catch (Exception) { return null; }

        }
        public static List<Mobile> AllMessage()
        {
            try
            {
                using (CourseMetarialEntities db = new CourseMetarialEntities())
                {
                    return db.Mobiles.ToList();
                }
            }
            catch (Exception) { return null; }

        }

        public static void UpdatePort(string Port) {
            using (CourseMetarialEntities db = new CourseMetarialEntities())
            {
                var dt = db.Mobiles.Where(m => m.Title == "Port").First();
                if (dt != null)
                {
                    dt.Message = Port;
                    db.SaveChanges();
                }
            }
           
        }

        public static string Port()
        {
            Mobile mob = Message("Port");
            return mob.Message;
        }

      
        public static void Send_sms(string Number, string msg)
        {
            try
            {
                SerialPort sp = new SerialPort();
                sp.PortName = Port();
                sp.BaudRate = 9600;
                sp.Parity = Parity.None;
                sp.Open();
                sp.WriteLine(@"AT" + (char)(13));
                Thread.Sleep(200);
                sp.WriteLine("AT+CMGF=1" + (char)(13));
                Thread.Sleep(200);
                sp.WriteLine(@"AT+CMGS=""" + Number + @"""" + (char)(13));
                Thread.Sleep(200);
                sp.WriteLine(msg + (char)(26));
                sp.Close();
                Thread.Sleep(6000);


                //sp.PortName =Port();
                //sp.Open();
                //string ph_no;
                //ph_no = Char.ConvertFromUtf32(34) + Number + Char.ConvertFromUtf32(34);
                //sp.Write("AT+CMGF=1" + Char.ConvertFromUtf32(13));
                //sp.Write("AT+CMGS=" + ph_no + Char.ConvertFromUtf32(13));
                //sp.Write(msg + Char.ConvertFromUtf32(26) + Char.ConvertFromUtf32(13));
                //sp.Close();

                //string s = (msg+ Char.ConvertFromUtf32(26) + Char.ConvertFromUtf32(13));

                //sp.PortName = Port();
                //sp.BaudRate = 96000;
                //sp.Parity = Parity.None;
                //sp.DataBits = 8;
                //sp.StopBits = StopBits.One;
                //sp.Handshake = Handshake.XOnXOff;
                //sp.DtrEnable = true;
                //sp.RtsEnable = true;
                //sp.NewLine = Environment.NewLine;
                //sp.Open();
                //int mSpeed = 1;
                //sp.Write("AT+CMGF=1" + Environment.NewLine);
                //System.Threading.Thread.Sleep(200);
                //sp.Write("AT+CSCS=GSM" + Environment.NewLine);
                //System.Threading.Thread.Sleep(200);
                //sp.Write("AT+CMGS=" + (char)34 + "+92" + Number
                //+ (char)34 + Environment.NewLine);
                //System.Threading.Thread.Sleep(200);
                //sp.Write(msg + (char)26);
                //System.Threading.Thread.Sleep(mSpeed);
                ////  IsSendEndIndex = true; R;
                //sp.Close();
                Thread.Sleep(3000);
                Shared.Message = Shared.Message + "\n Message sended to \t" + Number +"\n\a";

            }
            catch (Exception ex) {
                Shared.Message = ex.Message;
            }

        }
       


        public static void Send_sms_List(List<string> number, string msg)
        {

            try
            {
                foreach (var num in number)
                {
                    Send_sms(num, msg);
                }
            }
            catch (Exception) { }
        }

        public static void Delete(int id)
        {
         
                using (CourseMetarialEntities db = new CourseMetarialEntities())
                {
                    var dt= db.Mobiles.Where(m => m.ID == id).FirstOrDefault();
                if (dt!=null)
                {
                    db.Mobiles.Remove(dt);
                    db.SaveChanges();
                    Shared.Message = "Message has been deleted";
                }
                }
          
           

        }
    }
}