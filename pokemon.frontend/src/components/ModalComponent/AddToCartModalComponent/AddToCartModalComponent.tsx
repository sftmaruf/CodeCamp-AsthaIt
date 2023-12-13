import { useEditName } from "@/utilities/reactQuery/reactQueryHooks";
import { Button, Modal } from "antd";
import { useApplicationStore } from "@/stores/applicationStore";
import React, {
  FunctionComponent,
  Dispatch,
  SetStateAction,
  useState,
} from "react";
import SetDetails from "@/components/SetDetailsComponent/SetDetailsComponent";
import EditModal from "../EditModalComponent/EditModalComponent";
import { ISet } from '@/types';

interface PropsType {
  modalOpen: boolean;
  setModalOpen: Dispatch<SetStateAction<boolean>>;
  _set: ISet
}

const AddToCartModal: FunctionComponent<PropsType> = ({
  modalOpen,
  setModalOpen,
  _set
}) => {
  const addToCart = useApplicationStore((state) => state.addToCart);
  const [editModalOpen, setEditModalOpen] = useState(false);

  const handleEdit = () => {
    setEditModalOpen(!editModalOpen);
  };

  const { mutate: editName } =  useEditName();

  const handleUpdate = (newName: string) => {
    editName({setId: _set.id, newName: newName});
  };

  return (
    <>
      <Modal
        centered
        title={`${_set?.name}`}
        open={modalOpen}
        okText="Add To Cart"
        okButtonProps={{ className: "bg-black" }}
        onOk={() => addToCart({ ..._set!, timeStamp: Date.now() })}
        onCancel={() => setModalOpen(false)}
        footer={(_, { OkBtn, CancelBtn }) => (
          <>
            <CancelBtn />
            <Button onClick={() => handleEdit()}>Edit</Button>
            <OkBtn />
          </>
        )}>
        <SetDetails _data={_set!} />
      </Modal>

      <EditModal modalOpen={editModalOpen} setModalOpen={setEditModalOpen} handleUpdate={handleUpdate} />
    </>
  );
};

export default AddToCartModal;