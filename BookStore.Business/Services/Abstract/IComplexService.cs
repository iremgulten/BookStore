
using BookStore.Business.DataTransferObjects;

namespace BookStore.Business.Services.Abstract
{
    public interface IComplexService
    {
        void AddComplexData(ComplexAddDTO request);
    }
}
