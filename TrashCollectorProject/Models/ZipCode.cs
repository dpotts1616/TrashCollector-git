﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectorProject.Models
{
    public class ZipCode
    {
        [Key]
        public int Id { get; set; }
        //[DataType(DataType.PostalCode)]
        public string Code { get; set; }

    }
}