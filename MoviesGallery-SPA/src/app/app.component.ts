import { Component } from '@angular/core';
import { MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent {
  title = 'project';

  constructor(
    private matIconRegistry: MatIconRegistry,
    private domSanitizer: DomSanitizer,
  ) {

    this.matIconRegistry.addSvgIcon(
      'earth',
      this.domSanitizer.bypassSecurityTrustResourceUrl(
        '../assets/images/earth.svg'
      )
    );
    this.matIconRegistry.addSvgIcon(
      'calendar',
      this.domSanitizer.bypassSecurityTrustResourceUrl(
        '../assets/images/calendar.svg'
      )
    );
    this.matIconRegistry.addSvgIcon(
      'arrow',
      this.domSanitizer.bypassSecurityTrustResourceUrl(
        '../assets/images/arrow.svg'
      )
    );
    this.matIconRegistry.addSvgIcon(
      'favorite',
      this.domSanitizer.bypassSecurityTrustResourceUrl(
        '../assets/images/favorite.svg'
      )
    );
  }
}
