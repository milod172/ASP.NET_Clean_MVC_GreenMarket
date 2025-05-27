using System.ComponentModel.DataAnnotations.Schema;

namespace GreenMarket.Domain.Entities
{
    public abstract class BaseEntity<TKey> : IHasKey<TKey>, IDisposable
    {
        public TKey Id { get; set; } = default!;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public void UpdateModifiedDate()
        {
            ModifiedDate = DateTime.UtcNow;
        }

        [NotMapped]
        private bool IsDisposed { get; set; }
        #region Dispose
        public void Dispose()
        {
            Dispose(isDisposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (!IsDisposed)
            {
                if (isDisposing)
                {
                    DisposeUnmanagedResources();
                }

                IsDisposed = true;
            }
        }

        protected virtual void DisposeUnmanagedResources()
        {
        }

        ~BaseEntity()
        {
            Dispose(isDisposing: false);
        }
        #endregion Dispose
    }
}
