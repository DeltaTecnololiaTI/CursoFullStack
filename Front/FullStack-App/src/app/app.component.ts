import { Component } from '@angular/core';
//Todo componente tem um html, css, ts
@Component({
  selector: 'app-root', //mesmo nome do seletor que está dendro do arquivo index.html
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'FullStack-App';
}
