using back_octo_adventure.Models.FieldMatrix;
using back_octo_adventure.Models.GameMaster;
using back_octo_adventure.Models.PlayerCharacter;
using Microsoft.EntityFrameworkCore;

namespace back_octo_adventure.DBContext
{
    public class GameMasterContext : DbContext {

        public GameMasterContext(DbContextOptions<GameMasterContext> options) : base(options) { 
        
        }

        public DbSet<GameMaster> GameMasters { set; get; }
        //public DbSet<PlayFieldGrid> FieldGrids { set; get; }
        public DbSet<Character> Characters { set; get; }
        
    }
}
