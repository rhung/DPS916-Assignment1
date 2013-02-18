using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ClassLibraryCS
{
    public abstract class RecordBase
    {
        protected string userName;
        protected List<string> emailAddresses;

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

        public List<string> EmailAddresses
        {
            get
            {
                return emailAddresses;
            }
            set
            {
                emailAddresses = value;
            }
        }

        public void changeEmailOrder(int sourceIndex, int destinationIndex)
        {
            if (sourceIndex < emailAddresses.Count || destinationIndex <= emailAddresses.Count)
            {
                string email = emailAddresses[sourceIndex];
             
                if (sourceIndex > destinationIndex)
                {
                    emailAddresses.Insert(destinationIndex, email);
                    emailAddresses.RemoveAt(sourceIndex + 1);
                }
                else
                {
                    emailAddresses.Insert(destinationIndex + 1, email);
                    emailAddresses.RemoveAt(sourceIndex);
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
