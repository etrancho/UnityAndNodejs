module.exports = (sequelize, Sequelize) => {
    const Regalo = sequelize.define("regalo", {
        idR: {
            type: Sequelize.INTEGER,
            primaryKey: true,
            autoIncrement: true
        },
        nombreR: {
            type: Sequelize.STRING
        },
        descripcionR: {
            type: Sequelize.STRING
        },
        precioR: {
            type: Sequelize.STRING
        }
    });

    return Regalo;
};