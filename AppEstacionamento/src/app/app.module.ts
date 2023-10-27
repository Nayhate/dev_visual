import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http'; 
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule} from 'ngx-bootstrap/modal';

import { MarcasService } from './marcas.service';
import { MarcasComponent } from './components/marcas/marcas.component';
import { ModelosService } from './modelos.service';
import { ModelosComponent } from './components/modelos/modelos.component';
import { ClientesService } from './clientes.service';
import { ClientesComponent } from './components/clientes/clientes.component';
import { CarrosService } from './carros.service';
import { CarrosComponent } from './components/carros/carros.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    MarcasComponent,
    ModelosComponent,
    ClientesComponent,
    CarrosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    BrowserAnimationsModule
  ],
  providers: [
    HttpClientModule,
    MarcasService,
    ModelosService,
    ClientesService,
    CarrosService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }