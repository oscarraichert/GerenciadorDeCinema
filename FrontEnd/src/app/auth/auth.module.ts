import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AuthService } from './services/auth.service';
import { LocalStorageService } from './services/local-storage.service';
import { LoginGuard } from './services/login.guard';
import { AuthGuard } from './services/auth.guard';



@NgModule({
  declarations: [
    LoginComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule
  ],
  providers: [
    AuthService,
    LocalStorageService,
    LoginGuard,
    AuthGuard
  ]
})
export class AuthModule { }
