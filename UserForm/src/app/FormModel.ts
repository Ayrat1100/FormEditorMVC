export class Form {
    Name: string;
    Description: string;
    Blocks: Block[];
  }
  export class Block {
    Header: string;
    TextField: string;
    Mandatory: boolean;
    FieldsType: string;
  }