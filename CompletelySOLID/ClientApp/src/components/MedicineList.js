import React, {Component} from 'react'
import DataTable from 'react-data-table-component';

const state = {medicine:[]};
const columns =[
{
    name:'Id',
    selector:'medicineId',
    sortable:true
},{
    name:'Name',
    selector:'medicineName',
    sortable:true
},{
    name:'Type',
    selector:'medicineType',
    sortable:true
},
{
    name:'Cost',
    selector:'cost',
    sortable:true
},
]
class MedicineList extends Component
{
    render(){
        return(<DataTable
                title="Pharmacy Medicine"
                columns={columns}
                data={state.medicine}/>)
    }
}
export default MedicineList