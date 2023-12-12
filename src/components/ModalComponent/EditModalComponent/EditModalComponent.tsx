import { Input, Modal } from "antd";
import React, { FunctionComponent, useState } from "react";

interface PropsType {
  modalOpen: boolean;
  setModalOpen: (decision: boolean) => void;
  handleUpdate: (newName: string) => void;
}

const EditModal: FunctionComponent<PropsType> = ({
  modalOpen,
  setModalOpen,
  handleUpdate,
}) => {
  const [newName, setNewName] = useState<string>("");
  const [showError, setShowError] = useState<boolean>(false);

  const handleOk = () => {
    if (newName.trim() === "") {
      setShowError(!showError);
      return;
    }

    handleUpdate(newName);
    setModalOpen(false);
  };

  return (
      <Modal
        centered
        title={"Edit name"}
        open={modalOpen}
        okText="Change"
        okButtonProps={{ className: "bg-black" }}
        onOk={handleOk}
        onCancel={() => setModalOpen(false)}>
        <Input onChange={(e) => setNewName(e.target.value)} />
        {
          showError ? <small className='text-red-500'>*New name is required</small> : <></>
        }
      </Modal>
  );
};

export default EditModal;
