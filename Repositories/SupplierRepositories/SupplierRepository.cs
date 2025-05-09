using CRUD_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_API.Repositories.SupplierRepositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly InventoryContext _context;
        public SupplierRepository(InventoryContext context) 
        {
            _context = context;        
        }
        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier?> GetSupplierByIdAsync(int supplierId)
        {
            return await _context.Suppliers.FindAsync(supplierId);  
        }
        public async Task<Supplier> AddSupplierAsync(Supplier supplier)
        {
            await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();

            return await _context.Suppliers.FirstOrDefaultAsync(s => s.Id == supplier.Id) ?? supplier;    
        }
        public async Task<Supplier> UpdateSupplierAsync(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync();

            return await _context.Suppliers.FirstOrDefaultAsync(s => s.Id == supplier.Id) ?? supplier;
        }
        public async Task DeleteSupplierAsync(Supplier supplier)
        {
            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
        }
    }
}
