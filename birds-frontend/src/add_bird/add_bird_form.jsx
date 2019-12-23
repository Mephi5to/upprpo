import React from 'react';

class AddBirdForm extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            warningEnabled: false
        };
    }

    render() {

        if (!this.props.enabled) {
            return null;
        }

        return (
            <div className="addBirdForm">
                <div className="addBirtFormTitle">
                    Добавление новой птицы
                </div>

                <div className="formWrapper">
                    <div>
                        <label htmlFor="name">Название*</label>
                        <input id="name"
                               className="nameInput"
                               type="text"
                               name="name" required/>
                    </div>
                    <div className="birdDescription">
                        <label className="descriptionLabel"
                               htmlFor="name">Описание*</label>
                        <textarea id="descr"
                                  className="descriptionInput"
                                  name="name" required/>
                    </div>
                    <div className="birdImageInput">
                        <label htmlFor="name">Изображение*</label>
                        <input id="img"
                               className="fileInput"
                               type="file"
                               name="name" required/>
                    </div>
                    <div className="birdAudioInput">
                        <label htmlFor="name">Запись голоса*</label>
                        <input id="audio"
                               className="fileInput"
                               type="file"
                               name="name" required/>
                    </div>
                    <Warning enabled={this.state.warningEnabled}>
                    </Warning>
                </div>

                <div className="addBirdFormButtons">
                    <div className="formButton"
                         onClick={() => {
                             this.setWarningEnabled(false);
                             this.props.closeFormFunc();
                         }}>
                        <span className="buttonTextCancel">Отмена</span>
                    </div>
                    <div className="formButton"
                         onClick={() => {
                             this.addBird();
                         }}>
                        <span className="buttonTextCreate">Добавить</span>
                    </div>
                </div>
            </div>
        );
    }

    addBird() {

        let name = document.getElementById("name").value;
        let description = document.getElementById("descr").value;
        let image = document.getElementById("img").value;
        let audio = document.getElementById("audio").value;

        if (!name || name.length < 1 || !description || description.length < 1 || !image || !audio) {
            this.setWarningEnabled(true);
            return null;
        }

        debugger;

        // todo api call
        // todo фильтрануть файлы по типу в форме

    }

    setWarningEnabled = (value) => {
        this.setState({
            warningEnabled: value
        })
    }
}

const Warning = (props) => {

    if (!props.enabled) {
        return null;
    }

    return <div className="warning">
        Пожалуйста, заполните все обязательные поля, которые отмечены *
    </div>;
};

export default AddBirdForm;
