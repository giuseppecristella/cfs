using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Utility
{
    public class MailManager
    {
       private List<string> _mailToList;
		private string _mailFrom;
		private List<string> _mailCcList;
		private List<string> _mailBccList;
		private string _mailSubject;
		private string _mailReplyTo;
		private string _mailSmtp;
		private string _mailTemplate;
		private string _TemplateType;
		private Hashtable _mailParameters;
		private MailPriority _priority;
		public List<string> MailToList
		{
			get
			{
				return this._mailToList;
			}
			set
			{
				this._mailToList = value;
			}
		}
		public string MailTo
		{
			set
			{
				this.splitAddress(value, ref this._mailToList);
			}
		}
		public string MailFrom
		{
			get
			{
				return this._mailFrom;
			}
			set
			{
				this._mailFrom = value;
			}
		}

        public string DisplayName { get; set; }

		public List<string> MailCcList
		{
			get
			{
				return this._mailCcList;
			}
			set
			{
				this._mailCcList = value;
			}
		}
		public string MailCc
		{
			set
			{
				this.splitAddress(value, ref this._mailCcList);
			}
		}
		public List<string> MailBccList
		{
			get
			{
				return this._mailBccList;
			}
			set
			{
				this._mailBccList = value;
			}
		}
		public string MailBcc
		{
			set
			{
				this.splitAddress(value, ref this._mailBccList);
			}
		}
		public string MailSubject
		{
			get
			{
				return this._mailSubject;
			}
			set
			{
				this._mailSubject = value;
			}
		}
		public string MailReplyTo
		{
			get
			{
				return this._mailReplyTo;
			}
			set
			{
				this._mailReplyTo = value;
			}
		}
		public string MailSmtp
		{
			get
			{
				return this._mailSmtp;
			}
			set
			{
				this._mailSmtp = value;
			}
		}
		public string MailTemplate
		{
			get
			{
				return this._mailTemplate;
			}
			set
			{
				this._mailTemplate = value;
			}
		}
		public string TemplateType
		{
			get
			{
				return this._TemplateType;
			}
			set
			{
				this._TemplateType = value;
			}
		}
		public Hashtable MailParameters
		{
			get
			{
				return this._mailParameters;
			}
			set
			{
				this._mailParameters = value;
			}
		}
		public MailPriority Priority
		{
			get
			{
				return this._priority;
			}
			set
			{
				this._priority = value;
			}
		}
		public MailManager()
		{
		}
        public MailManager(string mailTo, string mailFrom, string mailSubject, string mailTemplate)
		{
			this._mailFrom = mailFrom;
			this._mailSubject = mailSubject;
			this._mailTemplate = mailTemplate;
			this._mailParameters = new Hashtable();
			this._mailToList = new List<string>();
			this.splitAddress(mailTo, ref this._mailToList);
		}
		private void splitAddress(string mails, ref List<string> recipient)
		{
			if (recipient == null)
			{
				recipient = new List<string>();
			}
			string[] array = mails.Split(new char[]
			{
				';'
			});
			for (int i = 0; i < array.Length; i++)
			{
				if (!string.IsNullOrEmpty(array[i].ToString()))
				{
					recipient.Add(array[i].ToString());
				}
			}
		}
		private string GenerateBody()
		{
			StreamReader streamReader = new StreamReader(this.MailTemplate, Encoding.Default);
			StringBuilder stringBuilder = new StringBuilder(streamReader.ReadToEnd());
			streamReader.Close();
			if (this._mailParameters != null)
			{
				foreach (DictionaryEntry dictionaryEntry in this._mailParameters)
				{
					stringBuilder.Replace(dictionaryEntry.Key.ToString(), (dictionaryEntry.Value != null) ? dictionaryEntry.Value.ToString() : string.Empty);
				}
			}
			byte[] bytes = Encoding.Unicode.GetBytes(stringBuilder.ToString());
			return Encoding.Unicode.GetString(bytes);
		}
		private static bool Format(string Template)
		{
			string strA = Template.Substring(Template.LastIndexOf("."), Template.Length - Template.LastIndexOf("."));
			return string.Compare(strA, ".html", true, CultureInfo.CurrentCulture) == 0 || string.Compare(strA, ".htm", true, CultureInfo.CurrentCulture) == 0;
		}
		public void SendMail()
		{
			string message = "";
			if (!this.SendMail(out message))
			{
                //LogHelper.append("SlotManagementEngine: SendMail", message, LogType.ERROR);
			}
		}
		public bool SendMail(out string errMessage)
		{
			MailMessage mailMessage = new MailMessage();
			SmtpClient smtpClient = new SmtpClient();
			errMessage = "";
			bool result;
			try
			{
				if (!string.IsNullOrEmpty(this.MailFrom) && this._mailToList != null && this._mailToList.Count > 0)
				{
                    mailMessage.IsBodyHtml = Format(this.MailTemplate);

                    mailMessage.From = (string.IsNullOrEmpty(DisplayName)) ? new MailAddress(MailFrom) : new MailAddress(MailFrom, DisplayName);
					foreach (string current in this._mailToList)
					{
						mailMessage.To.Add(new MailAddress(current));
					}
					if (MailCcList != null)
					{
						foreach (string current2 in this.MailCcList)
						{
							mailMessage.CC.Add(new MailAddress(current2));
						}
					}
					if (MailBccList != null)
					{
						foreach (string current3 in this.MailBccList)
						{
							mailMessage.Bcc.Add(new MailAddress(current3));
						}
					}
					if (!string.IsNullOrEmpty(this.MailReplyTo))
					{
						mailMessage.Headers.Add("Reply-To", this.MailReplyTo);
					}
					mailMessage.Subject = this.MailSubject;
					mailMessage.Body = this.GenerateBody();
					mailMessage.Priority = this._priority;
					smtpClient.Send(mailMessage);
					result = true;
				}
				else
				{
					errMessage = "Send Mail Error: Incomplete destination data";
					result = false;
				}
			}
			catch (Exception ex)
			{
				errMessage = "Send Mail Error: " + ex.Message;
				result = false;
			}
			finally
			{
				mailMessage = null;
				smtpClient = null;
			}
			return result;
		}


    }
}
