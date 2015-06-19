using System;

namespace AccountsPayable
{
    public abstract class TaxEntity
    {
        private string _taxId;

        protected TaxEntity(String taxId)
        {
            TaxId = taxId;
        }

        public virtual string TaxId
        {
            get { return _taxId; }
            set
            {
                if (value != null && value.Matches(TaxIdRegex))
                {
                    _taxId = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        protected abstract string TaxIdRegex { get; }

        public abstract float Pay();
    }
}