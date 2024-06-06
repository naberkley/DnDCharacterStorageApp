$(document).ready(function () {
    console.log("characterForm.js loaded");

    ////////////////////////////////////////////
    // Handle tooltips/popovers
    // Initialize the tooltip with a delay
    $('[data-toggle="tooltip"]').tooltip({
        trigger: 'hover',
        delay: { "show": 100, "hide": 100 }
    });
    ////////////////////////////////////////////

    ////////////////////////////////////////////
    // Handle character sheet dynamic stats

    // Function to calculate modifier
    function calculateModifier(score) {
        return Math.floor((score - 10) / 2);
    }

    // Function to calculate proficiency bonus
    function calculateProficiencyBonus(level) {
        return Math.ceil(level / 4) + 1;
    }

    // Function to calculate save bonus
    function calculateSaveBonus(modifier, hasSaveProficiency, proficiencyBonus) {
        return modifier + (hasSaveProficiency ? proficiencyBonus : 0);
    }

    // Function to format text
    function formatText(value) {
        return value >= 0 ? "+" + value : value;
    }

    // Function to update modifiers, proficiency bonuses, and save bonuses
    function updateScores() {
        $('input[name^="AbilitiesList["][name$=".Score"]').each(function () {
            var score = $(this).val();
            var level = $('input[name="Level"]').val();
            var hasSaveProficiency = $(this).closest('tr').find('input[name$=".HasSaveProficiency"]').is(':checked');
            var modifier = calculateModifier(score);
            var proficiencyBonus = calculateProficiencyBonus(level);
            var saveBonus = calculateSaveBonus(modifier, hasSaveProficiency, proficiencyBonus);
            var modifierText = formatText(modifier);
            var proficiencyBonusText = formatText(proficiencyBonus);
            var saveBonusText = formatText(saveBonus);

            $(this).closest('tr').find('.modifier').text(modifierText);
            $(this).closest('tr').find('input[name$=".Modifier"]').val(modifier);
            $('.proficiency-bonus').text(proficiencyBonusText);
            $('input[name="ProficiencyBonus"]').val(proficiencyBonus);
            $(this).closest('tr').find('.save-bonus').text(saveBonusText);
            $(this).closest('tr').find('input[name$=".SaveBonus"]').val(saveBonus);

            // Update skill scores
            var abilityName = $(this).closest('tr').find('input[name$=".AbilityName"]').val();
            $('td:contains("' + abilityName + '")').each(function () {
                var proficiencyCheckbox = $(this).closest('tr').find('input[name$=".HasProficiency"]');
                var hasProficiency = proficiencyCheckbox.is(':checked');
                var expertiseCheckbox = $(this).closest('tr').find('input[name$=".HasExpertise"]');
                var hasExpertise = expertiseCheckbox.is(':checked');
                var newSkillScore = parseInt(modifier);

                // Initialize the disabled property of the proficiencyCheckbox
                proficiencyCheckbox.prop('disabled', false);

                if (hasExpertise) {
                    newSkillScore = modifier + (proficiencyBonus * 2);
                    proficiencyCheckbox.prop('checked', true);
                    proficiencyCheckbox.prop('disabled', true);
                } else {
                    if (hasProficiency) {
                        newSkillScore = modifier + proficiencyBonus;
                    }
                    proficiencyCheckbox.prop('disabled', false); // Re-enable the checkbox when hasExpertise is false
                }

                $(this).closest('tr').find('.skill-score').text(formatText(newSkillScore));
                $(this).closest('tr').find('input.skill-score-input').val(formatText(newSkillScore));
            });

        });
    }

    // Function to set initial state of hasProficiency checkbox
    function setInitialState() {
        console.log("setInitialState()");
        $('input[name$=".HasExpertise"]').each(function () {
            var expertiseCheckbox = $(this);
            var proficiencyCheckbox = expertiseCheckbox.closest('tr').find('input[name$=".HasProficiency"]');
            if (expertiseCheckbox.is(':checked')) {
                proficiencyCheckbox.prop('disabled', true);
            } else {
                proficiencyCheckbox.prop('disabled', false);
            }
        });
    }

    // Call setInitialState function when page loads
    setInitialState();

    // Event handlers for changes that should trigger an update
    console.log("Setting up event handlers");
    $('input[name^="AbilitiesList["][name$=".Score"], input[name="Level"], input[name$=".HasSaveProficiency"], input[name$=".HasProficiency"], input[name$=".HasExpertise"]').on('input change', updateScores);
});