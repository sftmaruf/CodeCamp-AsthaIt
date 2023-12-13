import AddToCartModal from "@/components/ModalComponent/AddToCartModalComponent/AddToCartModalComponent";
import { ISet } from "@/types";
import { Flex } from "antd";
import React, { FunctionComponent, useState } from "react";

const EditOutlined: FunctionComponent<{_modalInfo: ISet}> = ({ _modalInfo}) => {
    const [modalOpen, setModalOpen] = useState<boolean>(false);

    const handleOnClick = () => setModalOpen(true);

    return (
        <>
            <Flex onClick={() => handleOnClick()}  justify='center' align='center' className='h-[50px] hover:bg-red-100'>
                <svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                    <path d="M17.9998 12H18.0088" stroke="#141B34" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round"/>
                    <path d="M5.99981 12H6.00879" stroke="#141B34" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round"/>
                    <path d="M11.9959 12H12.0049" stroke="#141B34" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round"/>
                </svg>
            </Flex>
            <AddToCartModal modalOpen={modalOpen} setModalOpen={setModalOpen} _set={_modalInfo}/>
        </>
    );
};

export default EditOutlined;
