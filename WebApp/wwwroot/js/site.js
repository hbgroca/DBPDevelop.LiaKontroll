document.addEventListener('DOMContentLoaded', () => {
    // Open Modal and assing click function on them
    const modalButtons = document.querySelectorAll('[data-modal="true"]');
    modalButtons.forEach(button => {
        button.addEventListener('click', () => {
            const modalTarget = button.getAttribute('data-target');
            const modal = document.querySelector(modalTarget);

            // If the modal exists, show it
            if (modal) {
                modal.style.display = 'flex';
            }
        });
    });

    // Find all close buttons and assing click function on them
    const modalCloseButtons = document.querySelectorAll('[data-close="true"]');
    modalCloseButtons.forEach(button => {
        button.addEventListener('click', () => {
            const modalTarget = button.closest('.modal');
            // If the modal exists, hide it
            if (modalTarget) {
                modalTarget.style.display = 'none';

                // Clear form input fileds
                modalTarget.querySelectorAll('form').forEach(form => {
                    form.reset();
                });

            }
        });
    });


    // Handle Submit forms
    const forms = document.querySelectorAll('.modal form');
    forms.forEach(form => {
        form.addEventListener('submit', async (e) => {
            e.preventDefault();

            clearErrorMessages(form);

            // Create a new form data object
            const formData = new FormData(form);
            try {
                const response = await fetch(form.action, {
                    method: 'post',
                    body: formData
                });

                // If Response is OK, close the modal and reload page
                if (response.ok) {
                    const modal = form.closest('.modal');
                    if (modal)
                        modal.style.display = 'none';

                    window.location.reload();
                }
                // If Response is not OK, show error messages
                else if (response.status === 400) {
                    const data = await response.json();

                    if (data.errors) {
                        Object.keys(data.errors).forEach(key => {
                            console.log(data)

                            // Find the input element that matches key value and add error class
                            const input = form.querySelector(`[name="${key}"]`)
                            if (input) {
                                input.classList.add('input-validation-error');
                            }
                            // Find the span element that matches key value and add error message
                            const errorSpan = form.querySelector(`[data-valmsg-for="${key}"]`);
                            if (errorSpan) {
                                errorSpan.innerText = data.errors[key].join('\n');
                                errorSpan.classList.add('field-validation-error');
                            }
                        });
                    }

                }
            }

            catch (error) {
                console.error("Failed to submit form: ", error);
            }

        });
    });
})

// View the delete confirm buttons
function viewDeleteConfirmButtons(e) {
    if (!e) return;
    // Find the closest form
    var deleteButtonsContainer = e.closest('.remove-form');
    if (!deleteButtonsContainer) {
        console.error('Could not find .remove-form element');
        return;
    }

    // Get the remove button and toggle its visibility
    var deleteButton = deleteButtonsContainer.querySelector('.pop-up-btn');
    if (deleteButton) deleteButton.classList.toggle('hidden');

    // Get the confirmation buttons and toggle their visibility
    var deleteConfirmButtons = deleteButtonsContainer.querySelector('.pop-up-remove-btns');
    if (deleteConfirmButtons) deleteConfirmButtons.classList.toggle('hidden');
}

// Clear error messages
function clearErrorMessages(form) {
    // Clear all input validation messages
    form.querySelectorAll('[data-val="true"]').forEach(input => {
        input.classList.remove('input-validation-error');
    })

    // Clear all validation messages
    form.querySelectorAll('[data-valmsg-for]').forEach(span => {
        span.innerText = '';
        span.classList.remove('field-validation-error');
    })
}


const validateField = (field) => {
    // Get the error span for the field
    let errorSpan = document.querySelector(`span[data-valmsg-for='${field.name}']`)
    if (!errorSpan) {
        console.error(`Could not find a span with the data-valmsg-for attribute equal to ${field.name}`)
        return;
    }

    let errorMessage = ""
    let value = field.value.trim()


    // Check if the value is required
    if (field.hasAttribute("data-val-required") && value === "")
        errorMessage = field.getAttribute("data-val-required")


    // Check if the value is a valid email
    if (field.hasAttribute("data-val-regex") && value !== "") {
        let pattern = new RegExp(field.getAttribute("data-val-regex-pattern"))
        if (!pattern.test(value))
            errorMessage = field.getAttribute("data-val-regex")
    }

    // Show or remove error msg
    if (errorMessage) {
        field.classList.add("input-validation-error")
        errorSpan.classList.remove("field-validation-valid")
        errorSpan.classList.add("field-validation-error")
        errorSpan.textContent = errorMessage
    } else {
        field.classList.remove("input-validation-error")
        errorSpan.classList.remove("field-validation-error")
        errorSpan.classList.add("field-validation-valid")
        errorSpan.textContent = ""
    }
}

document.addEventListener('DOMContentLoaded', function () {
    const form = document.querySelector('form')

    if (!form) {
        console.error("Could not find a form element")
        return;
    }


    // Get all the fields that need to be validated
    const fields = form.querySelectorAll("input[data-val='true']")

    // Add an event listener to each field
    fields.forEach(field => {
        field.addEventListener("input", function () {
            validateField(field)
        })
    })
})

