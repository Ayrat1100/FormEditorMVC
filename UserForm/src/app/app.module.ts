import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule }   from '@angular/forms';
import { AppComponent } from './app.component';
import { HttpClientModule} from '@angular/common/http';
import {Routes, RouterModule} from '@angular/router';
import { FormComponent } from './form.component';
const appRoutes: Routes =[
  { path: 'api/Forms/:id', component: FormComponent}
  
];

@NgModule({
  imports:      [ BrowserModule, FormsModule,HttpClientModule,RouterModule.forRoot(appRoutes)],
  declarations: [ AppComponent, FormComponent],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
