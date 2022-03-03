const db = require("../models");
const Regalo = db.regalo;
const Op = db.Sequelize.Op;

// Create and Save a new regalo
exports.create = (req, res) => {
  // Validate request
  if (!req.body.idE) {
    res.status(400).send({
      message: "Content can not be empty!"
    });
    return;
  }

  // Create a regalo
  const regalo = {
    idR: req.body.idR,
    nombreR: req.body.nombreR,
    descripcionR: req.body.descripcionR,
    precioR: req.body.precioR
  };

  // Save regalo in the database
  Regalo.create(regalo)
    .then(data => {
      res.send(data);
    })
    .catch(err => {
      res.status(500).send({
        message:
          err.message || "Some error occurred while creating it."
      });
    });
};

// Retrieve all regalos from the database.
exports.findAll = (req, res) => {
  Regalo.findAll().then(data => {
      res.send(data);
    })
    .catch(err => {
      res.status(500).send({
        message: err.message || "Some error occurred while retrieving it."
      });
    });
};

// Find a single regalo with an id
exports.findOne = (req, res) => {
  const idR = req.params.idR;

  Regalo.findByPk(idR)
    .then(data => {
      res.send(data);
    })
    .catch(err => {
      res.status(500).send({
        message: "Error retrieving regalo with idR =" + idR
      });
    });
};

// Update a REGALO by the id in the request
exports.update = (req, res) => {
  const idR = req.params.idR;

  Regalo.update(req.body, {
    where: { idR: idR }
  })
    .then(num => {
      if (num == 1) {
        res.send({
          message: "It was updated successfully."
        });
      } else {
        res.send({
          message: `Cannot update Regalo with idR=${idR}. 
            Maybe it was not found or req.body is empty!`
        });
      }
    })
    .catch(err => {
      res.status(500).send({
        message: "Error updating Regalo with idR =" + idR
      });
    });
};

// Delete a regalo with the specified id in the request
exports.delete = (req, res) => {
  const idR = req.params.idR;

  Empresa.destroy({
    where: { idR: idR }
  })
    .then(num => {
      if (num == 1) {
        res.send({
          message: "Regalo was deleted successfully!"
        });
      } else {
        res.send({
          message: `Cannot delete Regalo with idR = ${idR}. Maybe Regalo was not found!`
        });
      }
    })
    .catch(err => {
      res.status(500).send({
        message: "Could not delete Regalo with idR=" + idR
      });
    });
};