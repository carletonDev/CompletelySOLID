import PharmacyList from '../components/Pharmacy';
import connect from 'react-redux'
import { Component } from 'react';
import getPharmacy from '../store/PharmacyActions/getPharmacy'


class PharmacyContainer extends Component
{

        render(){
            <PharmacyList/>
        }
}

const mapStateToProps=(state)=>{
    return state
}
export default connect(mapStateToProps,getPharmacy)(PharmacyContainer)