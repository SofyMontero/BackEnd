
import { Routes } from '@angular/router';
import { UsuariosComponent } from './app.usuarios'; // Asegúrate de que el componente exista

export const routes: Routes = [
  { path: 'usuarios', component: UsuariosComponent }, // Define la ruta
  { path: '', redirectTo: '/usuarios', pathMatch: 'full' } // Redirección opcional
];

export class AppRoutingModule {}