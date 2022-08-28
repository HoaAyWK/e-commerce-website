import React, { useEffect } from 'react';
import { SelectChangeEvent } from '@mui/material';

import BasicSelect from '../../components/select/BasicSelect';
import { useAppDispatch, useAppSelector } from '../../app/hook';
import { fetchBrands } from './brandsSlice';

export namespace BrandSelection {
    export interface Props {
        value: '' | string;
        handleValueChange: (event: SelectChangeEvent) => void;
    }
}

const BrandSelection = ({ value, handleValueChange }: BrandSelection.Props) => {
    const data = useAppSelector((state) => state.brands.data);
    const brandStatus = useAppSelector((state) => state.brands.status);
    const dispatch = useAppDispatch();

    useEffect(() => {
        if (brandStatus === 'idle')
            dispatch(fetchBrands());
            
    }, [dispatch, brandStatus])

    return (
        <BasicSelect
            name='brand'
            label='Brand'
            value={value}
            data={data}
            handleChange={handleValueChange}
        />
    );
};

export default BrandSelection;