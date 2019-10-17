import React from 'react'
import DataTable from 'react-data-table-component';
import * as Pharmacy from '../store/reducers/Pharmacy';
export const state={
    pharmacy:[]
}
//declare column heads
const columns =[
{
    name:'Id',
    selector:'pharmacyId',
    sortable:true
},
{
    name:'Name',
    selector:'pharmacyName',
    sortable:true
},
{
    name:'Address',
    selector:'pharmacyAddress',
    sortable:true
},
{
    name:'City',
    selector:'city',
    sortable:true
},
{
    name:'State',
    selector:'state',
    sortable:true
},
{
    name:'Zip',
    selector:'zip',
    sortable:true
},
{
    name:'PharmacyMedicine',
    selector:'pharmacyMedicine',
    sortable:true
},
{
    name:'Salary',
    selector:'salary',
    sortable:true
}
]
class PharmacyList extends React.Component{


    render(){
        return(<DataTable
                title="Pharmacy List"
                columns={columns}
                data={state.pharmacy}/>)
    }
}
export default PharmacyList;