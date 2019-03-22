
import { Component, Renderer2, ViewChild, ElementRef } from '@angular/core';
import { HttpService } from './http.service';
import { createContainerRef } from '@angular/core/src/render3/view_engine_compatibility';
import { HttpClient} from '@angular/common/http'
import {Form} from './FormModel'
@Component({
  selector: 'from-app',
  templateUrl:  './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent {
  @ViewChild('userform')
  private userform: ElementRef;
  

  form: Form;
  done: boolean = false;
  
  constructor(private httpService: HttpService, private renderer: Renderer2) {
    this.httpService.getFactorial(window.location.pathname).subscribe((data: Form) => {
      this.form = data; this.done = true;
      this.formBuilder(this.form, renderer);
    });
  }

  formBuilder(form: Form, renderer: Renderer2) {
    let formHeader = renderer.createElement('p');
    renderer.addClass(formHeader,'form-header');
    renderer.appendChild(formHeader, renderer.createText(form.Name));
    this.renderer.appendChild(this.userform.nativeElement, formHeader);

    let formDescription = renderer.createElement('p');
    renderer.addClass(formDescription,'form-desc');
    renderer.appendChild(formDescription, renderer.createText(form.Description));
    this.renderer.appendChild(this.userform.nativeElement, formDescription);


    form.Blocks.forEach(element => {

      let blockContainer = renderer.createElement('div');
      renderer.addClass(blockContainer, 'row');

      let blockHeader = renderer.createElement('div');
      renderer.addClass(blockHeader, 'col-3');
      renderer.appendChild(blockHeader, renderer.createText(element.Header));
      renderer.appendChild(blockContainer, blockHeader);
      renderer.addClass(blockContainer, 'form-element');
      
      // simple input
      if (element.FieldsType == '1') {
        let blockElement = renderer.createElement('input');
        this.BuildElement(renderer, blockElement);
        renderer.addClass(blockElement, 'col');
        renderer.setAttribute(blockElement, 'placeholder', element.TextField);
        renderer.appendChild(blockContainer, blockElement);
      }

      // text area
      if (element.FieldsType == '2') {
        let blockElement = renderer.createElement('textarea');
        this.BuildElement(renderer, blockElement);
        renderer.addClass(blockElement, 'col');
        renderer.appendChild(blockElement, renderer.createText(''));
        renderer.setAttribute(blockElement, 'placeholder', element.TextField);
        renderer.appendChild(blockContainer, blockElement);
      }

      // radio btn group
      if (element.FieldsType == '3') {
        let str = element.TextField.split(' ');
        let chBoxblockContainer = renderer.createElement('div');
        renderer.addClass(chBoxblockContainer, 'col');

        let CheckContainer = renderer.createElement('div');
        for (let i = 0; i < str.length; i++) {
          let chbCon = renderer.createElement('input');
          renderer.setAttribute(chbCon, 'type', 'radio');
          renderer.setAttribute(chbCon, 'name', 'Name');
          let label = renderer.createElement('label');
          renderer.addClass(label,'label-class');
          renderer.setAttribute(chbCon, 'id', i.toString()+'rad');
          renderer.setAttribute(label, 'for', i.toString()+'rad');
          let paragraph = renderer.createElement('p');
          renderer.appendChild(chbCon, renderer.createText(element[i]));
          renderer.appendChild(label, renderer.createText(str[i]));
          renderer.appendChild(paragraph, chbCon);
          renderer.appendChild(paragraph, label);
          renderer.appendChild(CheckContainer, paragraph);
        }
        renderer.addClass(chBoxblockContainer, 'col');
        renderer.appendChild(blockContainer, CheckContainer);
      }

      //checkbox group
      if (element.FieldsType == '4') {
        let str = element.TextField.split(' ');
        let radioBlockContainer = renderer.createElement('div');
        renderer.addClass(radioBlockContainer, 'col');

        let CheckContainer = renderer.createElement('div');
        for (let i = 0; i < str.length; i++) {
          let chbCon = renderer.createElement('input');
          let label = renderer.createElement('label');
          renderer.addClass(label,'label-class');
          renderer.setAttribute(chbCon, 'type', 'checkbox');
          renderer.setAttribute(chbCon, 'id', i.toString());
          renderer.setAttribute(label, 'for', i.toString());
          let paragraph = renderer.createElement('p');

          renderer.appendChild(chbCon, renderer.createText(element[i]));
          renderer.appendChild(label, renderer.createText(str[i]));
          renderer.appendChild(paragraph, chbCon);
          renderer.appendChild(paragraph, label);
          renderer.appendChild(CheckContainer, paragraph);
        }

        renderer.addClass(radioBlockContainer, 'col');
        renderer.appendChild(blockContainer, CheckContainer);
      }

      //drop list
      if (element.FieldsType == '5') {
        let Container = renderer.createElement('div');
        renderer.addClass(Container, 'col-3');
        renderer.addClass(Container, 'drop-container');
        let blockElement = renderer.createElement('select');
        renderer.addClass(blockElement, 'form-control');
        let str = element.TextField.split(' ');
        for (let i = 0; i < str.length; i++) {
          let ElementOption = renderer.createElement('option');
          renderer.setAttribute(ElementOption, 'value', str[i]);
          renderer.appendChild(ElementOption, renderer.createText(str[i]));
          renderer.appendChild(blockElement, ElementOption);
        }
        renderer.appendChild(Container, blockElement);
        renderer.appendChild(blockContainer, Container);
      }
      this.renderer.appendChild(this.userform.nativeElement, blockContainer);
    });
    let btnContainer = renderer.createElement('div');
    renderer.addClass(btnContainer, 'row');
    renderer.addClass(btnContainer, 'justify-content-end');
    
    let Submit = renderer.createElement('button');
    renderer.addClass(Submit, 'btn-success');
    let ButtonText = renderer.createText('Отправить');
    renderer.appendChild(Submit, ButtonText);
    this.renderer.appendChild(btnContainer, Submit);
    this.renderer.appendChild(this.userform.nativeElement, btnContainer);
  }

  BuildElement(renderer: Renderer2, element: any) {
    renderer.addClass(element, 'form-control');
    let blockHeaderText = renderer.createText(element.TextField);
    renderer.appendChild(element, blockHeaderText);
    renderer.appendChild(this.userform.nativeElement, element);
  }
}