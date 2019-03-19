
import { Component, Renderer2, ViewChild, ElementRef} from '@angular/core';
import { HttpService} from './http.service';
import { createContainerRef } from '@angular/core/src/render3/view_engine_compatibility';
@Component({
    selector: 'from-app',
    template: `<div class="container"><form >
    <div #userform></div>
    </form></div>`,
})
export class FormComponent 
{
  @ViewChild('userform') 
  private userform: ElementRef;


  form: Form;
  done: boolean = false;
  constructor(private httpService: HttpService,private renderer: Renderer2)
  {
      this.httpService.getFactorial(window.location.pathname).subscribe((data:Form) => {
      this.form = data; this.done = true;
      this.formBuilder(this.form, renderer);
    });
  }

  formBuilder(form:Form,renderer:Renderer2)
  {
    let formHeader = renderer.createElement('p');
    let formHeaderText = renderer.createText(form.Name);
    renderer.appendChild(formHeader,formHeaderText);
    this.renderer.appendChild(this.userform.nativeElement, formHeader);

    let formDescription = renderer.createElement('p');
    let formDescriptionText = renderer.createText(form.Description);
    renderer.appendChild(formDescription,formDescriptionText);
    this.renderer.appendChild(this.userform.nativeElement, formDescription);


    form.Blocks.forEach(element => {
      
      let blockContainer = renderer.createElement('div');
      renderer.addClass(blockContainer,'row');

      let blockHeader = renderer.createElement('div');
      renderer.addClass(blockHeader,'col-3');
      renderer.appendChild(blockHeader,renderer.createText(element.Header));
      renderer.appendChild(blockContainer,blockHeader);

      if(element.FieldsType=='1')
      {
        let blockElement = renderer.createElement('input');
        this.BuildElement(renderer,blockElement);
        renderer.addClass(blockElement,'col');
        renderer.setAttribute(blockElement,'placeholder',element.TextField);
        renderer.appendChild(blockContainer,blockElement);
      }
      if(element.FieldsType=='2')
      {
        let blockElement = renderer.createElement('textarea');
        this.BuildElement(renderer,blockElement);
        renderer.addClass(blockElement,'col');
        renderer.setAttribute(blockElement,'placeholder',element.TextField);
        renderer.appendChild(blockContainer,blockElement);
      }
      if(element.FieldsType=='3')
      {
        let str = element.TextField.split(' ');
        let chBoxblockContainer = renderer.createElement('div');
        renderer.addClass(chBoxblockContainer,'col');

        let CheckContainer = renderer.createElement('div');
        for (let i = 0; i < str.length; i++)
        {
          let chbCon = renderer.createElement('input');
          renderer.setAttribute(chbCon,'type','radio');
          //renderer.addClass(chbCon,'form-control');
          renderer.setAttribute(chbCon,'name','Name');
          let paragraph = renderer.createElement('p');
          
          renderer.appendChild(paragraph,chbCon);
          renderer.appendChild(paragraph,renderer.createText(str[i]));

          renderer.appendChild(CheckContainer, paragraph);
        }


        renderer.addClass(chBoxblockContainer,'col');
        renderer.appendChild(blockContainer,CheckContainer);
      }
      if(element.FieldsType=='4')
      {
        let str = element.TextField.split(' ');
        let chBoxblockContainer = renderer.createElement('div');
        renderer.addClass(chBoxblockContainer,'col');

        let CheckContainer = renderer.createElement('div');
        for (let i = 0; i < str.length; i++)
        {
          let chbCon = renderer.createElement('input');
          let label = renderer.createElement('lable');
          renderer.setAttribute(chbCon,'type','checkbox');
          //renderer.addClass(chbCon,'form-control');
          renderer.setAttribute(chbCon,'id',i.toString());
          renderer.setAttribute(label,'for',i.toString());
          let paragraph = renderer.createElement('p');

          renderer.appendChild(chbCon,renderer.createText(element[i]));
          renderer.appendChild(label,renderer.createText(str[i]));
          renderer.appendChild(paragraph,chbCon);
          renderer.appendChild(paragraph,label);

         
          renderer.appendChild(CheckContainer, paragraph);
        }

        renderer.addClass(chBoxblockContainer,'col');
        renderer.appendChild(blockContainer,CheckContainer);
      }
      if(element.FieldsType == '5')
      {
        let Container = renderer.createElement('div');
        renderer.addClass(Container,'col-3');

        let blockElement = renderer.createElement('select');
        renderer.addClass(blockElement,'form-control');
        //renderer.addClass(blockElement,'col');
        let str = element.TextField.split(' ');
        for (let i = 0; i < str.length; i++)
        {
          let ElementOption = renderer.createElement('option');
          renderer.setAttribute(ElementOption,'value',str[i]);
          renderer.appendChild(ElementOption,renderer.createText(str[i]));
          renderer.appendChild(blockElement,ElementOption);
        }
        renderer.appendChild(Container,blockElement);
        renderer.appendChild(blockContainer,Container);
      }
      this.renderer.appendChild(this.userform.nativeElement,blockContainer);
    });
    let Submit = renderer.createElement('button');
    renderer.addClass(Submit,'btn-success');
    let ButtonText = renderer.createText('Отправить');
    renderer.appendChild(Submit,ButtonText);
    this.renderer.appendChild(this.userform.nativeElement, Submit);
  }

  BuildElement(renderer:Renderer2,element:any)
  {
    renderer.addClass(element,'form-control');
    let blockHeaderText = renderer.createText(element.TextField);
    renderer.appendChild(element,blockHeaderText);
    renderer.appendChild(this.userform.nativeElement, element);
  }
}



 

class Form{
  Name: string;
  Description: string;
  Blocks: Block[];
}
class Block{
  Header: string;
  TextField: string;
  Mandatory: boolean;
  FieldsType: string;
}