// <copyright file="ContextInitializer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditor.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class ContextInitializer : DropCreateDatabaseAlways<FormContext>
    {
        protected override void Seed(FormContext db)
        {
            Form form1 = new Form { Guid = Guid.NewGuid().ToString(), Name = "Test form1", Description = "Description of test form1" };
            Form form2 = new Form { Guid = Guid.NewGuid().ToString(), Name = "Test form2", Description = "Description of test form2" };
            Form form3 = new Form { Guid = Guid.NewGuid().ToString(), Name = "Test form3", Description = "Description of test form3" };

            db.Forms.Add(form1);
            db.Forms.Add(form2);
            db.Forms.Add(form3);
            db.SaveChanges();

            Block block1 = new Block { Header = "Block of form1", Mandatory = true, FieldsType = FieldsType.Paragraph, TextField = "block1text of form1", Form = form1 };
            Block block2 = new Block { Header = "Block of form1", Mandatory = false, FieldsType = FieldsType.DropdownList, TextField = "block2text of form1", Form = form1 };
            Block block3 = new Block { Header = "Block of form1", Mandatory = true, FieldsType = FieldsType.Paragraph, TextField = "block2text of form1", Form = form1 };

            Block block4 = new Block { Header = "Block of form2", Mandatory = false, FieldsType = FieldsType.SeveralFromTheList, TextField = "block4text of form2", Form = form2 };
            Block block5 = new Block { Header = "Block of form2", Mandatory = true, FieldsType = FieldsType.TextString, TextField = "block5text of form2", Form = form2 };

            Block block6 = new Block { Header = "Block of form3", Mandatory = false, FieldsType = FieldsType.OneOfTheList, TextField = "block1text of form3", Form = form3 };
            Block block7 = new Block { Header = "Block of form3", Mandatory = false, FieldsType = FieldsType.TextString, TextField = "block2text of form3", Form = form3 };
            Block block8 = new Block { Header = "Block of form3", Mandatory = true, FieldsType = FieldsType.Paragraph, TextField = "block2text of form3", Form = form3 };

            db.Blocks.AddRange(new List<Block> { block1, block2, block3, block4, block5, block6, block7, block8 });
            db.SaveChanges();
        }
    }
}