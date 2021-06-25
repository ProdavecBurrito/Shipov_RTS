using System;
using System.Collections.Generic;
using UnityEngine;

public class CommandButtonsPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;
    [SerializeField] private CommandButtonsView _view;
    [SerializeField] private AssetsContext _context;

    private ISelectable _currentSelectable;

    private void Start()
    {
        _selectable.OnSelected += OnSelected;
        OnSelected(_selectable.CurrentValue);

        _view.OnClick += OnButtonClick;
    }

    private void OnSelected(ISelectable selectable)
    {
        if (_currentSelectable == selectable)
        {
            return;
        }
        _currentSelectable = selectable;

        _view.Clear();
        if (selectable != null)
        {
            var commandExecutors = new List<ICommandExecutor>();
            commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
            _view.MakeLayout(commandExecutors);
        }
    }

    private void OnButtonClick(ICommandExecutor commandExecutor)
    {
        var unitProducer = commandExecutor as CommandExecutorBase<IProduceUnitCommand>;
        if (unitProducer != null)
        {
            unitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommandHeir()));
            return;
        }
        var unitAttack = commandExecutor as CommandExecutorBase<IAttackCommand>;
        if (unitAttack != null)
        {
            unitAttack.ExecuteSpecificCommand(_context.Inject(new AttackCommand()));
            return;
        }
        var unitMove = commandExecutor as CommandExecutorBase<IMoveCommand>;
        if (unitMove != null)
        {
            unitMove.ExecuteSpecificCommand(_context.Inject(new MoveCommand()));
            return;
        }
        var unitHold = commandExecutor as CommandExecutorBase<IHoldCommand>;
        if (unitHold != null)
        {
            unitHold.ExecuteSpecificCommand(_context.Inject(new HoldCommand()));
            return;
        }
        var unitPatrol = commandExecutor as CommandExecutorBase<IPatrolCommand>;
        if (unitPatrol != null)
        {
            unitPatrol.ExecuteSpecificCommand(_context.Inject(new PatrolCommand()));
            return;
        }
        throw new ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(OnButtonClick)}: Unknown type of commands executor: {commandExecutor.GetType().FullName}!");
    }
}
