import { Component, OnInit} from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { HttpService } from './http.service';
export class User{
  name: string;
  age: number;
}
@Component({
  selector: 'my-app',
  template: `<router-outlet></router-outlet>`,
  providers: [HttpService]
})
export class AppComponent {}