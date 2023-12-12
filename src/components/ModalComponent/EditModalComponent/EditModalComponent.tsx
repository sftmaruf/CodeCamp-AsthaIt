import { Form, Input, Modal } from "antd";
import React, { FunctionComponent, useState } from "react";

interface PropsType {
    modalOpen: boolean;
    setModalOpen: (decision: boolean) => void;
    setId: string,
    handleUpdate: (newName: string) => void
}

const EditModal: FunctionComponent<PropsType> = ({ modalOpen, setModalOpen, setId, handleUpdate }) => {
  const [newName, setNewName] = useState<string>('');

  return (
    <Modal
      centered
      title={"Edit name"}
      open={modalOpen}
      okText="Change"
      okButtonProps={{ className: "bg-black" }}
      onOk={() => {
        handleUpdate(newName);
        setModalOpen(false);
      }}
      onCancel={() => setModalOpen(false)}>
      <Form>
        <Input onChange={(e) => setNewName(e.target.value)}/>
      </Form>
    </Modal>
  );
};

export default EditModal;
