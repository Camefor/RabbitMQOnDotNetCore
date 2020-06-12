using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreRabbitMQ.ClientService.Models {


    /// <summary>
    /// 实体类
    /// </summary>
    [Table("TClientDetails")]
    public class Client {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Sex")]
        public string Sex { get; set; }
    }
}
