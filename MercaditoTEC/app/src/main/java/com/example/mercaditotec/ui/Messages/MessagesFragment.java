package com.example.mercaditotec.ui.Messages;

import androidx.lifecycle.ViewModelProvider;

import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.example.mercaditotec.R;

import org.w3c.dom.Text;

public class MessagesFragment extends Fragment {

    private MessagesViewModel mViewModel;
    private View Vista;

    public static MessagesFragment newInstance() {
        return new MessagesFragment();
    }

    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container,
                             @Nullable Bundle savedInstanceState) {
        Vista = inflater.inflate(R.layout.messages_fragment, container, false);

        return Vista;
    }

    @Override
    public void onActivityCreated(@Nullable Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);
        mViewModel = new ViewModelProvider(this).get(MessagesViewModel.class);
        // TODO: Use the ViewModel
    }

}