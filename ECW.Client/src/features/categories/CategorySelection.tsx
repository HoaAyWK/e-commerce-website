import React, { useEffect } from 'react';
import { SelectChangeEvent } from '@mui/material';

import BasicSelect from '../../components/select/BasicSelect';
import { useAppDispatch, useAppSelector } from '../../app/hook';
import { fetchCategories } from './categoriesSlice';

export namespace CategorySelection {
    export interface Props {
        value: '' | string;
        handleValueChange: (event: SelectChangeEvent) => void;
    }
};

const CategorySelection = ({ value, handleValueChange }: CategorySelection.Props) => {
    const data = useAppSelector((state) => state.categories.data);
    const categoryStatus = useAppSelector((state) => state.categories.status);
    const dispatch = useAppDispatch();

    useEffect(() => {
        if (categoryStatus === 'idle')
            dispatch(fetchCategories());
            
    }, [dispatch, categoryStatus])

    return (
        <BasicSelect
            name='category'
            label='Category'
            value={value}
            data={data}
            handleChange={handleValueChange}
        />
    );
};

export default CategorySelection;