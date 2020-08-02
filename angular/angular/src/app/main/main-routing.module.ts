import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { PhoneBookComponent } from './phoneBook/phoneBook.component';
import { NewPersonComponent } from './phoneBook/newperson/newperson.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                children: [
                    {
                        path: 'dashboard',
                        component: DashboardComponent,
                        data: { permission: 'Pages.Tenant.Dashboard' },
                    },
                    { path: 'phonebook', component: PhoneBookComponent },
                    { path: 'newperson', component: NewPersonComponent },
                ],
            },
        ]),
    ],
    exports: [RouterModule],
})
export class MainRoutingModule { }
