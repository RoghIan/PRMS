import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './admin.component';
import { PublisherComponent } from './publisher/publisher.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [AdminComponent, PublisherComponent],
  imports: [CommonModule, SharedModule],
  exports: [AdminComponent],
})
export class AdminModule {}
