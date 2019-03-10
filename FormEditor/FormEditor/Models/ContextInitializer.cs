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
            Form form1 = new Form()
            {
                Guid = Guid.NewGuid().ToString(), Name = "Test form1", Description = "Description of test form1", Blocks =
                new List<Block>()
                {
                    new Block { Header = "Block of form1", Mandatory = true, FieldsType = FieldsType.Paragraph, TextField = "block1text of form1" },
                    new Block { Header = "Block of form1", Mandatory = false, FieldsType = FieldsType.DropdownList, TextField = "block2text of form1", },
                    new Block { Header = "Block of form1", Mandatory = true, FieldsType = FieldsType.Paragraph, TextField = "block2text of form1" }
                }
            };
            form1.Blocks[0].Form = form1;
            form1.Blocks[1].Form = form1;
            form1.Blocks[2].Form = form1;

            Form form2 = new Form
            {
                Guid = Guid.NewGuid().ToString(), Name = "Test form2", Description = "Description of test form2", Blocks =
                new List<Block>()
                {
                   new Block { Header = "Block of form2", Mandatory = false, FieldsType = FieldsType.SeveralFromTheList, TextField = "block4text of form2" },
                   new Block { Header = "Block of form2", Mandatory = true, FieldsType = FieldsType.TextString, TextField = "block5text of form2" }
                }
            };

            form2.Blocks[0].Form = form2;
            form2.Blocks[1].Form = form2;
            Form form3 = new Form
            {
                Guid = Guid.NewGuid().ToString(), Name = "Test form3", Description = "Description of test form3",
                Blocks =
                new List<Block>()
                {
                  new Block { Header = "Block of form3", Mandatory = false, FieldsType = FieldsType.OneOfTheList, TextField = "block1text of form3" },
                  new Block { Header = "Block of form3", Mandatory = false, FieldsType = FieldsType.TextString, TextField = "block2text of form3" },
                  new Block { Header = "Block of form3", Mandatory = true, FieldsType = FieldsType.Paragraph, TextField = "block2text of form3" }
                }
            };
            form3.Blocks[0].Form = form3;
            form3.Blocks[1].Form = form3;
            form3.Blocks[2].Form = form3;

            db.Forms.Add(form1);
            db.Forms.Add(form2);
            db.Forms.Add(form3);
            db.SaveChanges();
        }
    }
}